using G1.Stripe.Maui.Platforms.iOS.Converters;
using Microsoft.Extensions.Configuration;
using PassKit;
using Stripe;
using UIKit;

namespace G1.Stripe.Maui.Options;

partial class PaymentSheetOptions
{
    internal TSPSConfiguration BuildPlatform()
    {
        var configuration = new TSPSConfiguration
        {
            MerchantDisplayName = MerchantDisplayName,
            AllowsDelayedPaymentMethods = AllowsDelayedPaymentMethods
        };

        if (ApplePay is { } applePayOptions)
        {
            var appleConfig = new TSPSApplePayConfiguration(
                applePayOptions.MerchantId,
                applePayOptions.CountryCode,
                PKPaymentButtonType.Checkout,
                null,
                null
            );

            configuration.ApplePay = appleConfig;
        }

        if (BillingDetails is { } billingDetails)
        {
            configuration.BillingDetailsCollectionConfiguration = billingDetails.ToPlatform();
        }

        if (Customer is { } customer)
        {
            configuration.Customer = customer.ToPlatform();
        }

        if (Appearance is { } app)
        {
            var currentStyle = UIScreen.MainScreen.TraitCollection.UserInterfaceStyle;

            bool isDarkMode = currentStyle == UIUserInterfaceStyle.Dark;

            var lightPrimaryButtonBackground = app.Light?.PrimaryButtonBackground?.ToUIColor() ?? UIColor.SystemBlue;
            var lightPrimaryButtonText = app.Light?.PrimaryButtonOnBackground?.ToUIColor() ?? UIColor.White;
            var lightBackground = app.Light?.Surface?.ToUIColor() ?? UIColor.White;
            var lightText = app.Light?.Primary?.ToUIColor() ?? UIColor.Black;
            var lightSecondaryText = app.Light?.SecondaryText?.ToUIColor() ?? UIColor.Gray;
            var lightPlaceholder = app.Light?.PlaceholderText?.ToUIColor() ?? UIColor.Gray;
            var lightError = app.Light?.Error?.ToUIColor() ?? UIColor.Red;

            var darkPrimaryButtonBackground = app.Dark?.PrimaryButtonBackground?.ToUIColor() ?? UIColor.SystemBlue;
            var darkPrimaryButtonText = app.Dark?.PrimaryButtonOnBackground?.ToUIColor() ?? UIColor.White;
            var darkBackground = app.Dark?.Surface?.ToUIColor() ?? UIColor.Black;
            var darkText = app.Dark?.Primary?.ToUIColor() ?? UIColor.White;
            var darkSecondaryText = app.Dark?.SecondaryText?.ToUIColor() ?? UIColor.LightGray;
            var darkPlaceholder = app.Dark?.PlaceholderText?.ToUIColor() ?? UIColor.LightGray;
            var darkError = app.Dark?.Error?.ToUIColor() ?? UIColor.Red;

            var primaryButtonBackground = isDarkMode ? darkPrimaryButtonBackground : lightPrimaryButtonBackground;
            var primaryButtonText = isDarkMode ? darkPrimaryButtonText : lightPrimaryButtonText;
            var background = isDarkMode ? darkBackground : lightBackground;
            var text = isDarkMode ? darkText : lightText;
            var secondaryText = isDarkMode ? darkSecondaryText : lightSecondaryText;
            var placeholder = isDarkMode ? darkPlaceholder : lightPlaceholder;
            var error = isDarkMode ? darkError : lightError;

            var baseFont = !string.IsNullOrEmpty(app.FontFamilyForiOS)
                ? UIFont.FromName(app.FontFamilyForiOS, app.FontSize ?? 16)
                : UIFont.SystemFontOfSize(app.FontSize ?? 16);

            var primaryButtonFont = !string.IsNullOrEmpty(app.PrimaryButtonFontFamilyForiOS)
                ? UIFont.FromName(app.PrimaryButtonFontFamilyForiOS, app.PrimaryButtonFontSize ?? 16)
                : UIFont.BoldSystemFontOfSize(app.PrimaryButtonFontSize ?? 16);

            var cornerRadius = (app.CornerRadius ?? 8);
            var buttonCornerRadius = (app.PrimaryButtonCornerRadius ?? 8);

            var iosAppearance = new TSPSAppearance();

            // Colors.Primary is Stripe's brand/accent color (links, focus borders, checkmarks).
            // We use the C# Primary brand color here; PrimaryButton.BackgroundColor handles the button.
            iosAppearance.Colors.Primary = text;
            iosAppearance.Colors.Background = background;
            iosAppearance.Colors.TextSecondary = secondaryText;
            iosAppearance.Colors.ComponentPlaceholderText = placeholder;
            iosAppearance.Colors.Danger = error;

            var lightComponent = app.Light?.Component?.ToUIColor();
            var darkComponent = app.Dark?.Component?.ToUIColor();
            var lightOnComponent = app.Light?.OnComponent?.ToUIColor();
            var darkOnComponent = app.Dark?.OnComponent?.ToUIColor();
            if (lightComponent is not null || darkComponent is not null)
                iosAppearance.Colors.ComponentBackground = isDarkMode ? darkComponent : lightComponent;
            if (lightOnComponent is not null || darkOnComponent is not null)
                iosAppearance.Colors.ComponentText = isDarkMode ? darkOnComponent : lightOnComponent;

            iosAppearance.PrimaryButton.BackgroundColor = primaryButtonBackground;
            iosAppearance.PrimaryButton.TextColor = primaryButtonText;
            iosAppearance.PrimaryButton.CornerRadius = (app.PrimaryButtonCornerRadius ?? app.CornerRadius ?? 8);
            iosAppearance.PrimaryButton.Font = primaryButtonFont;

            var lightBorder = app.Light?.PrimaryButtonBorder?.ToUIColor();
            var darkBorder = app.Dark?.PrimaryButtonBorder?.ToUIColor();
            var border = isDarkMode ? darkBorder : lightBorder;
            if (border is not null)
                iosAppearance.PrimaryButton.BorderColor = border;

            iosAppearance.Font.Base = baseFont;

            iosAppearance.CornerRadius = (app.CornerRadius ?? 8);

            configuration.Appearance = iosAppearance;
        }

        return configuration;
    }
}