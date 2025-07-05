import Foundation
import StripePayments
import StripeCore

// MARK: - Payment Method Types
@objc public enum TSPSPaymentMethodType: Int {
    case card = 0
    case cardPresent
    case iDEAL
    case SEPA
    case AUBECSDebit
    case bacsDebit
    case sofort
    case UPI
    case netBanking
    case unknown
    
    internal func toStripePaymentMethodType() -> STPPaymentMethodType {
        switch self {
        case .card: return .card
        case .cardPresent: return .cardPresent
        case .iDEAL: return .iDEAL
        case .SEPA: return .SEPADebit
        case .AUBECSDebit: return .AUBECSDebit
        case .bacsDebit: return .bacsDebit
        case .sofort: return .sofort
        case .UPI: return .UPI
        case .netBanking: return .netBanking
        case .unknown: return .unknown
        }
    }
    
    internal static func fromStripePaymentMethodType(_ type: STPPaymentMethodType) -> TSPSPaymentMethodType {
        switch type {
        case .card: return .card
        case .cardPresent: return .cardPresent
        case .iDEAL: return .iDEAL
        case .SEPADebit: return .SEPA
        case .AUBECSDebit: return .AUBECSDebit
        case .bacsDebit: return .bacsDebit
        case .sofort: return .sofort
        case .UPI: return .UPI
        case .netBanking: return .netBanking
        default: return .unknown
        }
    }
}

// MARK: - Card Brand
@objc public enum TSPSCardBrand: Int {
    case visa = 0
    case amex
    case masterCard
    case discover
    case JCB
    case dinersClub
    case unionPay
    case unknown
    
    internal func toStripeCardBrand() -> STPCardBrand {
        switch self {
        case .visa: return .visa
        case .amex: return .amex
        case .masterCard: return .mastercard
        case .discover: return .discover
        case .JCB: return .JCB
        case .dinersClub: return .dinersClub
        case .unionPay: return .unionPay
        case .unknown: return .unknown
        }
    }
    
    internal static func fromStripeCardBrand(_ brand: STPCardBrand) -> TSPSCardBrand {
        switch brand {
        case .visa: return .visa
        case .amex: return .amex
        case .mastercard: return .masterCard
        case .discover: return .discover
        case .JCB: return .JCB
        case .dinersClub: return .dinersClub
        case .unionPay: return .unionPay
        default: return .unknown
        }
    }
}

// MARK: - NSNumber Extension for Card Brand
extension NSNumber {
    @objc public var cardBrand: STPCardBrand {
        return STPCardBrand(rawValue: self.intValue) ?? .unknown
    }
}

// MARK: - Payment Method
@objc(TSPSPaymentMethod)
public class TSPSPaymentMethod: NSObject {
    @objc public let stripeId: String
    @objc public let type: TSPSPaymentMethodType
    @objc public let billingDetails: TSPBillingDetails?
    @objc public let card: TSPSPaymentMethodCard?
    @objc public let created: Date?
    @objc public let customerId: String?
    @objc public let liveMode: Bool

    internal init(from stripePaymentMethod: STPPaymentMethod) {
        self.stripeId = stripePaymentMethod.stripeId
        self.type = TSPSPaymentMethodType.fromStripePaymentMethodType(stripePaymentMethod.type)
        // Simplified billing details handling
        self.billingDetails = nil // Will implement later when we have proper mapping
        self.card = stripePaymentMethod.card.map { TSPSPaymentMethodCard.fromStripeCard($0) }
        self.created = stripePaymentMethod.created
        self.customerId = stripePaymentMethod.customerId
        self.liveMode = false // Will set based on actual property availability
        super.init()
    }
}

// MARK: - Payment Method Card
@objc(TSPSPaymentMethodCard)
public class TSPSPaymentMethodCard: NSObject {
    @objc public let brand: TSPSCardBrand
    @objc public let last4: String?
    @objc public let expiryMonth: NSNumber?
    @objc public let expiryYear: NSNumber?
    @objc public let funding: String?
    @objc public let country: String?
    
    internal init(from stripeCard: STPPaymentMethodCard) {
        self.brand = TSPSCardBrand.fromStripeCardBrand(stripeCard.brand)
        self.last4 = stripeCard.last4
        self.expiryMonth = NSNumber(value: stripeCard.expMonth)
        self.expiryYear = NSNumber(value: stripeCard.expYear)
        self.funding = stripeCard.funding
        self.country = stripeCard.country
        super.init()
    }
    
    internal static func fromStripeCard(_ card: STPPaymentMethodCard) -> TSPSPaymentMethodCard {
        return TSPSPaymentMethodCard(from: card)
    }
}

// MARK: - Payment Intent
@objc(TSPSPaymentIntent)
public class TSPSPaymentIntent: NSObject {
    @objc public let stripeId: String
    @objc public let clientSecret: String
    @objc public let amount: NSNumber
    @objc public let currency: String
    @objc public let status: String
    @objc public let paymentMethod: TSPSPaymentMethod?
    @objc public let created: Date
    @objc public let liveMode: Bool
    
    internal init(from stripePaymentIntent: STPPaymentIntent) {
        self.stripeId = stripePaymentIntent.stripeId
        self.clientSecret = stripePaymentIntent.clientSecret
        self.amount = NSNumber(value: stripePaymentIntent.amount)
        self.currency = stripePaymentIntent.currency
        self.status = String(describing: stripePaymentIntent.status)
        self.paymentMethod = stripePaymentIntent.paymentMethod.map { TSPSPaymentMethod(from: $0) }
        self.created = stripePaymentIntent.created
        self.liveMode = false // Will implement when property is available
        super.init()
    }
}

// MARK: - Setup Intent
@objc(TSPSSetupIntent)
public class TSPSSetupIntent: NSObject {
    @objc public let stripeId: String
    @objc public let clientSecret: String
    @objc public let status: String
    @objc public let paymentMethod: TSPSPaymentMethod?
    @objc public let created: Date
    @objc public let liveMode: Bool
    
    internal init(from stripeSetupIntent: STPSetupIntent) {
        self.stripeId = stripeSetupIntent.stripeID
        self.clientSecret = stripeSetupIntent.clientSecret
        self.status = String(describing: stripeSetupIntent.status)
        self.paymentMethod = stripeSetupIntent.paymentMethod.map { TSPSPaymentMethod(from: $0) }
        self.created = stripeSetupIntent.created
        self.liveMode = false // Will implement when property is available
        super.init()
    }
}
