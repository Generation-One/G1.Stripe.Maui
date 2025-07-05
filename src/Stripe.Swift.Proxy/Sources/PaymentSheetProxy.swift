import Foundation
import UIKit
import StripePaymentSheet
import StripeCore
import PassKit

// MARK: - PaymentSheet Result
@objc public enum TSPSPaymentSheetResult: Int {
    case completed = 0
    case canceled
    case failed
}

// MARK: - User Interface Style
@objc public enum TSPSUserInterfaceStyle: Int {
    case automatic = 0
    case alwaysLight
    case alwaysDark
}

// MARK: - Main PaymentSheet Wrapper
@objc(TSPSPaymentSheet)
public class TSPSPaymentSheet: NSObject {
    private var paymentSheet: PaymentSheet?
    
    @objc public convenience init(paymentIntentClientSecret: String, configuration: TSPSConfiguration) {
        STPAPIClient.shared
        self.init()
        let stripeConfiguration = configuration.toStripeConfiguration()
        self.paymentSheet = PaymentSheet(paymentIntentClientSecret: paymentIntentClientSecret, configuration: stripeConfiguration)
    }
    
    @objc public convenience init(setupIntentClientSecret: String, configuration: TSPSConfiguration) {
        self.init()
        let stripeConfiguration = configuration.toStripeConfiguration()
        self.paymentSheet = PaymentSheet(setupIntentClientSecret: setupIntentClientSecret, configuration: stripeConfiguration)
    }
    
    @objc public static func resetCustomer() {
        PaymentSheet.resetCustomer()
    }
    
    @objc public func present(from presentingViewController: UIViewController, completion: @escaping (TSPSPaymentSheetResult, Error?) -> Void) {
        guard let paymentSheet = self.paymentSheet else {
            completion(.failed, NSError(domain: "TSPSPaymentSheet", code: -1, userInfo: [NSLocalizedDescriptionKey: "PaymentSheet not initialized"]))
            return
        }
        
        paymentSheet.present(from: presentingViewController) { result in
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

// MARK: - Configuration
@objc(TSPSConfiguration)
public class TSPSConfiguration: NSObject {
    @objc public var merchantDisplayName: String?
    @objc public var customer: TSPSCustomerConfiguration?
    // GooglePay not available in current Stripe version
    // @objc public var googlePay: TSPSGooglePayConfiguration?
    // Apple Pay configuration not available in current Stripe version
    // @objc public var applePay: TSPSApplePayConfiguration?
    @objc public var primaryButtonColor: UIColor?
    @objc public var appearance: TSPSAppearance = TSPSAppearance.default
    @objc public var returnURL: String?
    @objc public var allowsDelayedPaymentMethods: Bool = false
    @objc public var userInterfaceStyle: TSPSUserInterfaceStyle = .automatic
    @objc public var paymentMethodOrder: [String]?
    
    @objc public override init() {
        super.init()
    }
    
    internal func toStripeConfiguration() -> PaymentSheet.Configuration {
        var config = PaymentSheet.Configuration()
        if let merchantDisplayName = self.merchantDisplayName {
            config.merchantDisplayName = merchantDisplayName
        }
        config.customer = self.customer?.toStripeCustomerConfiguration()
        // config.googlePay = self.googlePay?.toStripeGooglePayConfiguration()
        // config.applePay = self.applePay?.toStripeApplePayConfiguration()
        config.primaryButtonColor = self.primaryButtonColor
        config.appearance = self.appearance.toStripeAppearance()
        config.returnURL = self.returnURL
        config.allowsDelayedPaymentMethods = self.allowsDelayedPaymentMethods
        
        switch self.userInterfaceStyle {
        case .automatic:
            config.style = .automatic
        case .alwaysLight:
            config.style = .alwaysLight
        case .alwaysDark:
            config.style = .alwaysDark
        }
        
        config.paymentMethodOrder = self.paymentMethodOrder
        return config
    }
}

// MARK: - Customer Configuration
@objc(TSPSCustomerConfiguration)
public class TSPSCustomerConfiguration: NSObject {
    @objc public let id: String
    @objc public let ephemeralKeySecret: String
    
    @objc public init(id: String, ephemeralKeySecret: String) {
        self.id = id
        self.ephemeralKeySecret = ephemeralKeySecret
        super.init()
    }
    
    internal func toStripeCustomerConfiguration() -> PaymentSheet.CustomerConfiguration {
        return PaymentSheet.CustomerConfiguration(id: self.id, ephemeralKeySecret: self.ephemeralKeySecret)
    }
}

