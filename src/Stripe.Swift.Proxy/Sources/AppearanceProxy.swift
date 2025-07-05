import Foundation
import UIKit
import StripePaymentSheet

// MARK: - Appearance
@objc(TSPSAppearance)
public class TSPSAppearance: NSObject {
    @objc public static let `default` = TSPSAppearance()
    
    @objc public var font: TSPSAppearanceFont {
        return _font
    }
    private let _font = TSPSAppearanceFont()
    
    @objc public var colors: TSPSAppearanceColors {
        return _colors
    }
    private let _colors = TSPSAppearanceColors()
    
    @objc public var primaryButton: TSPSAppearancePrimaryButton {
        return _primaryButton
    }
    private let _primaryButton = TSPSAppearancePrimaryButton()
    
    @objc public var cornerRadius: CGFloat = 6.0
    @objc public var borderWidth: CGFloat = 1.0
    
    @objc public var shadow: TSPSAppearanceShadow {
        return _shadow
    }
    private let _shadow = TSPSAppearanceShadow()
    
    @objc public override init() {
        super.init()
    }
    
    internal func toStripeAppearance() -> PaymentSheet.Appearance {
        var appearance = PaymentSheet.Appearance.default
        appearance.font = self._font.toStripeFont()
        appearance.colors = self._colors.toStripeColors()
        appearance.primaryButton = self._primaryButton.toStripePrimaryButton()
        appearance.cornerRadius = self.cornerRadius
        appearance.borderWidth = self.borderWidth
        appearance.shadow = self._shadow.toStripeShadow()
        return appearance
    }
}

// MARK: - Appearance Font
@objc(TSPSAppearanceFont)
public class TSPSAppearanceFont: NSObject {
    @objc public var base: UIFont?
    @objc public var sizeScaleFactor: CGFloat = 1.0
    
    @objc public override init() {
        super.init()
    }
    
    internal func toStripeFont() -> PaymentSheet.Appearance.Font {
        var font = PaymentSheet.Appearance.Font()
        if let base = self.base {
            font.base = base
        }
        font.sizeScaleFactor = self.sizeScaleFactor
        return font
    }
}

// MARK: - Appearance Colors
@objc(TSPSAppearanceColors)
public class TSPSAppearanceColors: NSObject {
    @objc public var primary: UIColor?
    @objc public var background: UIColor?
    @objc public var componentBackground: UIColor?
    @objc public var componentBorder: UIColor?
    @objc public var componentDivider: UIColor?
    @objc public var text: UIColor?
    @objc public var textSecondary: UIColor?
    @objc public var componentText: UIColor?
    @objc public var componentPlaceholderText: UIColor?
    @objc public var icon: UIColor?
    @objc public var danger: UIColor?
    @objc public var warning: UIColor?
    
    @objc public override init() {
        super.init()
    }
    
    internal func toStripeColors() -> PaymentSheet.Appearance.Colors {
        var colors = PaymentSheet.Appearance.Colors()
        if let primary = self.primary { colors.primary = primary }
        if let background = self.background { colors.background = background }
        if let componentBackground = self.componentBackground { colors.componentBackground = componentBackground }
        if let componentBorder = self.componentBorder { colors.componentBorder = componentBorder }
        if let componentDivider = self.componentDivider { colors.componentDivider = componentDivider }
        if let text = self.text { colors.text = text }
        if let textSecondary = self.textSecondary { colors.textSecondary = textSecondary }
        if let componentText = self.componentText { colors.componentText = componentText }
        if let componentPlaceholderText = self.componentPlaceholderText { colors.componentPlaceholderText = componentPlaceholderText }
        if let icon = self.icon { colors.icon = icon }
        if let danger = self.danger { colors.danger = danger }
        // Note: warning property doesn't exist in current Stripe version
        // if let warning = self.warning { colors.warning = warning }
        return colors
    }
}

// MARK: - Appearance Primary Button
@objc(TSPSAppearancePrimaryButton)
public class TSPSAppearancePrimaryButton: NSObject {
    @objc public var backgroundColor: UIColor?
    @objc public var textColor: UIColor?
    @objc public var cornerRadius: CGFloat
    @objc public var borderColor: UIColor?
    @objc public var borderWidth: CGFloat = 0.0
    @objc public var font: UIFont?
    
    @objc public var shadow: TSPSAppearanceShadow {
        return _shadow
    }
    private let _shadow = TSPSAppearanceShadow()
    
    @objc public override init() {
        self.cornerRadius = 6.0
        super.init()
    }
    
    internal func toStripePrimaryButton() -> PaymentSheet.Appearance.PrimaryButton {
        var button = PaymentSheet.Appearance.PrimaryButton()
        if let backgroundColor = self.backgroundColor { button.backgroundColor = backgroundColor }
        if let textColor = self.textColor { button.textColor = textColor }
        button.cornerRadius = self.cornerRadius
        if let borderColor = self.borderColor { button.borderColor = borderColor }
        button.borderWidth = self.borderWidth
        if let font = self.font { button.font = font }
        button.shadow = self._shadow.toStripeShadow()
        return button
    }
}

// MARK: - Appearance Shadow
@objc(TSPSAppearanceShadow)
public class TSPSAppearanceShadow: NSObject {
    @objc public var color: UIColor?
    @objc public var opacity: CGFloat = 0.0
    @objc public var offset: CGSize = CGSize.zero
    @objc public var radius: CGFloat = 0.0
    
    @objc public override init() {
        super.init()
    }
    
    internal func toStripeShadow() -> PaymentSheet.Appearance.Shadow {
        var shadow = PaymentSheet.Appearance.Shadow()
        if let color = self.color { shadow.color = color }
        shadow.opacity = self.opacity
        shadow.offset = self.offset
        shadow.radius = self.radius
        return shadow
    }
}
