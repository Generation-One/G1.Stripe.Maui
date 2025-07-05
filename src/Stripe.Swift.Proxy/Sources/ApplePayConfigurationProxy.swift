import Foundation
import PassKit
import StripePaymentSheet

// MARK: - Apple Pay Configuration
@objc(TSPSApplePayConfiguration)
public class TSPSApplePayConfiguration: NSObject {
    @objc public let merchantId: String
    @objc public let merchantCountryCode: String
    @objc public let buttonType: PKPaymentButtonType
    @objc public let paymentSummaryItems: [PKPaymentSummaryItem]?
    @objc public let customHandlers: TSPSApplePayConfigurationHandlers?
    
    @objc public init(
        merchantId: String,
        merchantCountryCode: String,
        buttonType: PKPaymentButtonType = .plain,
        paymentSummaryItems: [PKPaymentSummaryItem]? = nil,
        customHandlers: TSPSApplePayConfigurationHandlers? = nil
    ) {
        self.merchantId = merchantId
        self.merchantCountryCode = merchantCountryCode
        self.buttonType = buttonType
        self.paymentSummaryItems = paymentSummaryItems
        self.customHandlers = customHandlers
        super.init()
    }
    
    // Apple Pay configuration not available in current Stripe version
    // internal func toStripeApplePayConfiguration() -> PaymentSheet.Configuration.ApplePay {
    //     return PaymentSheet.Configuration.ApplePay(
    //         merchantId: self.merchantId,
    //         merchantCountryCode: self.merchantCountryCode,
    //         buttonType: self.buttonType,
    //         paymentSummaryItems: self.paymentSummaryItems
    //     )
    // }
}

// MARK: - Apple Pay Configuration Handlers (Placeholder - not available in current Stripe version)
@objc(TSPSApplePayConfigurationHandlers)
public class TSPSApplePayConfigurationHandlers: NSObject {
    @objc public override init() {
        super.init()
    }

    // Custom handlers not available in current Stripe version
}

// MARK: - Address Details
@objc(TSPAddressDetails)
public class TSPAddressDetails: NSObject {
    @objc public var line1: String?
    @objc public var line2: String?
    @objc public var city: String?
    @objc public var state: String?
    @objc public var postalCode: String?
    @objc public var country: String?
    
    @objc public override init() {
        super.init()
    }
    
    @objc public init(
        line1: String? = nil,
        line2: String? = nil,
        city: String? = nil,
        state: String? = nil,
        postalCode: String? = nil,
        country: String? = nil
    ) {
        self.line1 = line1
        self.line2 = line2
        self.city = city
        self.state = state
        self.postalCode = postalCode
        self.country = country
        super.init()
    }
    
    internal func toStripeAddress() -> PaymentSheet.Address {
        return PaymentSheet.Address(
            city: self.city,
            country: self.country,
            line1: self.line1,
            line2: self.line2,
            postalCode: self.postalCode,
            state: self.state
        )
    }
    
    internal static func fromStripeAddress(_ address: PaymentSheet.Address) -> TSPAddressDetails {
        return TSPAddressDetails(
            line1: address.line1,
            line2: address.line2,
            city: address.city,
            state: address.state,
            postalCode: address.postalCode,
            country: address.country
        )
    }
}

// MARK: - Billing Details
@objc(TSPBillingDetails)
public class TSPBillingDetails: NSObject {
    @objc public var address: TSPAddressDetails?
    @objc public var email: String?
    @objc public var name: String?
    @objc public var phone: String?
    
    @objc public override init() {
        super.init()
    }
    
    @objc public init(
        address: TSPAddressDetails? = nil,
        email: String? = nil,
        name: String? = nil,
        phone: String? = nil
    ) {
        self.address = address
        self.email = email
        self.name = name
        self.phone = phone
        super.init()
    }
    
    internal func toStripeBillingDetails() -> PaymentSheet.BillingDetails {
        var billingDetails = PaymentSheet.BillingDetails()
        if let address = self.address {
            billingDetails.address = address.toStripeAddress()
        }
        billingDetails.email = self.email
        billingDetails.name = self.name
        billingDetails.phone = self.phone
        return billingDetails
    }
    
    internal static func fromStripeBillingDetails(_ billingDetails: PaymentSheet.BillingDetails) -> TSPBillingDetails {
        let addressDetails = TSPAddressDetails.fromStripeAddress(billingDetails.address)
        return TSPBillingDetails(
            address: addressDetails,
            email: billingDetails.email,
            name: billingDetails.name,
            phone: billingDetails.phone
        )
    }
}
