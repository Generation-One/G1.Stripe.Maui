import Foundation
import UIKit
import StripePaymentSheet

// MARK: - Flow Controller
@objc(TSPSPaymentSheetFlowController)
public class TSPSPaymentSheetFlowController: NSObject {
    private var flowController: PaymentSheet.FlowController?
    
    @objc public static func create(
        paymentIntentClientSecret: String,
        configuration: TSPSConfiguration,
        completion: @escaping (TSPSPaymentSheetFlowController?, Error?) -> Void
    ) {
        let stripeConfiguration = configuration.toStripeConfiguration()
        
        PaymentSheet.FlowController.create(
            paymentIntentClientSecret: paymentIntentClientSecret,
            configuration: stripeConfiguration
        ) { result in
            switch result {
            case .success(let flowController):
                let wrapper = TSPSPaymentSheetFlowController()
                wrapper.flowController = flowController
                completion(wrapper, nil)
            case .failure(let error):
                completion(nil, error)
            }
        }
    }
    
    @objc public static func create(
        setupIntentClientSecret: String,
        configuration: TSPSConfiguration,
        completion: @escaping (TSPSPaymentSheetFlowController?, Error?) -> Void
    ) {
        let stripeConfiguration = configuration.toStripeConfiguration()
        
        PaymentSheet.FlowController.create(
            setupIntentClientSecret: setupIntentClientSecret,
            configuration: stripeConfiguration
        ) { result in
            switch result {
            case .success(let flowController):
                let wrapper = TSPSPaymentSheetFlowController()
                wrapper.flowController = flowController
                completion(wrapper, nil)
            case .failure(let error):
                completion(nil, error)
            }
        }
    }
    
    // Note: PaymentOption is not available in current Stripe version
    // @objc public var paymentOption: TSPSPaymentOption? {
    //     guard let flowController = self.flowController else { return nil }
    //     return flowController.paymentOption.map { TSPSPaymentOption.fromStripePaymentOption($0) }
    // }
    
    @objc public func presentPaymentOptions(
        from presentingViewController: UIViewController,
        completion: @escaping () -> Void
    ) {
        guard let flowController = self.flowController else {
            completion()
            return
        }
        
        flowController.presentPaymentOptions(from: presentingViewController, completion: completion)
    }
    
    @objc public func confirm(
        from presentingViewController: UIViewController,
        completion: @escaping (TSPSPaymentSheetResult, Error?) -> Void
    ) {
        guard let flowController = self.flowController else {
            completion(.failed, NSError(domain: "TSPSFlowController", code: -1, userInfo: [NSLocalizedDescriptionKey: "FlowController not initialized"]))
            return
        }
        
        flowController.confirm(from: presentingViewController) { result in
            switch result {
            case .completed:
                completion(.completed, nil)
            case .canceled:
                completion(.canceled, nil)
            case .failed(let error):
                completion(.failed, error)
            }
        }
    }
}

// MARK: - Payment Option (Placeholder - not available in current Stripe version)
@objc(TSPSPaymentOption)
public class TSPSPaymentOption: NSObject {
    @objc public let label: String
    @objc public let image: UIImage

    @objc public init(label: String, image: UIImage) {
        self.label = label
        self.image = image
        super.init()
    }
}

// MARK: - Payment Sheet Button
@objc(TSPSPaymentButton)
public class TSPSPaymentButton: UIButton {
    private var flowController: TSPSPaymentSheetFlowController?
    
    @objc public var onPaymentOptionChanged: ((TSPSPaymentOption?) -> Void)?
    @objc public var onPaymentCompletion: ((TSPSPaymentSheetResult, Error?) -> Void)?
    
    @objc public override init(frame: CGRect) {
        super.init(frame: frame)
        setupButton()
    }
    
    @objc public required init?(coder: NSCoder) {
        super.init(coder: coder)
        setupButton()
    }
    
    private func setupButton() {
        addTarget(self, action: #selector(buttonTapped), for: .touchUpInside)
        updateButtonAppearance()
    }
    
    @objc public func configure(with flowController: TSPSPaymentSheetFlowController) {
        self.flowController = flowController
        updateButtonAppearance()
    }
    
    private func updateButtonAppearance() {
        // PaymentOption not available in current Stripe version
        setTitle("Select Payment Method", for: .normal)
        setImage(nil, for: .normal)
        onPaymentOptionChanged?(nil)
    }
    
    @objc private func buttonTapped() {
        guard let flowController = self.flowController,
              let presentingViewController = self.findViewController() else {
            return
        }
        
        // Present payment options first, then confirm
        flowController.presentPaymentOptions(from: presentingViewController) { [weak self] in
            DispatchQueue.main.async {
                self?.updateButtonAppearance()
                // After selection, confirm payment
                flowController.confirm(from: presentingViewController) { result, error in
                    DispatchQueue.main.async {
                        self?.onPaymentCompletion?(result, error)
                    }
                }
            }
        }
    }
}

// MARK: - UIView Extension
extension UIView {
    func findViewController() -> UIViewController? {
        if let nextResponder = self.next as? UIViewController {
            return nextResponder
        } else if let nextResponder = self.next as? UIView {
            return nextResponder.findViewController()
        } else {
            return nil
        }
    }
}
