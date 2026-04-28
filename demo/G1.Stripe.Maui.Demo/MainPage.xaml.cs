using System.Net.Http.Json;

namespace G1.Stripe.Maui.Demo
{
    public partial class MainPage : ContentPage
    {
        private static readonly Color BrandPurple    = Color.FromArgb("#664291"); // Primary / focus / accents
        private static readonly Color SurfaceMint    = Color.FromArgb("#E8F5E9"); // Sheet background
        private static readonly Color ComponentSky   = Color.FromArgb("#BBDEFB"); // Card/input background
        private static readonly Color OnComponentInk = Color.FromArgb("#0D47A1"); // Text on component
        private static readonly Color SecondaryTeal  = Color.FromArgb("#00695C"); // Secondary text
        private static readonly Color PlaceholderBrn = Color.FromArgb("#8D6E63"); // Placeholder text
        private static readonly Color ErrorMagenta   = Color.FromArgb("#C2185B"); // Error text
        private static readonly Color ButtonBgOrange = Color.FromArgb("#FB8C00"); // Pay button background
        private static readonly Color ButtonTxtBlack = Color.FromArgb("#000000"); // Pay button text
        private static readonly Color BorderRedish   = Color.FromArgb("#FF5252"); // Pay button border

        private HttpClient client = new HttpClient(GetInsecureHandler());
        private IPaymentSheet _paymentSheet;

        public MainPage(IPaymentSheet paymentSheet)
        {
            InitializeComponent();
            _paymentSheet = paymentSheet;
        }

        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                return true;
            };
            return handler;
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            var address = "http://localhost:5095/intent";
#if ANDROID
            address = "http://10.0.2.2:5095/intent";
#endif

            var data = await client.GetFromJsonAsync<PaymentInfo>(address);

            _paymentSheet.Initialize(data!.PublishableKey);
            var options = new Options.PaymentSheetOptions
            {
                ClientSecret = data.ClientSecret,
                Customer = new Options.PaymentSheetCustomerOptions(data.Ephemeral, data.CustomerId),
                MerchantDisplayName = "Test",
                AllowsDelayedPaymentMethods = true,
                BillingDetails = new Options.PaymentSheetBillingDetailsCollectionOptions
                {
                    Name = Options.BillingDetailsCollectionMode.Always,
                    Phone = Options.BillingDetailsCollectionMode.Always,
                    Email = Options.BillingDetailsCollectionMode.Always,
                    Address = Options.AddressCollectionMode.Full,
                    AttachDefaultsToPaymentMethod = false
                },
                Appearance = new Options.PaymentSheetAppearanceOptions
                {
                    Light = new Options.PaymentSheetColorTheme
                    {
                        Primary                   = BrandPurple,
                        Surface                   = SurfaceMint,
                        Component                 = ComponentSky,
                        OnComponent               = OnComponentInk,
                        SecondaryText             = SecondaryTeal,
                        PlaceholderText           = PlaceholderBrn,
                        Error                     = ErrorMagenta,
                        PrimaryButtonBackground   = ButtonBgOrange,
                        PrimaryButtonOnBackground = ButtonTxtBlack,
                        PrimaryButtonBorder       = BorderRedish
                    },
                    Dark = new Options.PaymentSheetColorTheme
                    {
                        Primary                   = BrandPurple,
                        Surface                   = SurfaceMint,
                        Component                 = ComponentSky,
                        OnComponent               = OnComponentInk,
                        SecondaryText             = SecondaryTeal,
                        PlaceholderText           = PlaceholderBrn,
                        Error                     = ErrorMagenta,
                        PrimaryButtonBackground   = ButtonBgOrange,
                        PrimaryButtonOnBackground = ButtonTxtBlack,
                        PrimaryButtonBorder       = BorderRedish
                    },
                    FontSize                  = 18,
                    PrimaryButtonFontSize     = 24,
                    CornerRadius              = 16,
                    PrimaryButtonCornerRadius = 4
                }
            };

            var result = await _paymentSheet.Open(options);

            await DisplayAlert("stripe result", result.ToString(), "Cancel");
        }


        public record PaymentInfo(string PublishableKey, string ClientSecret, string CustomerId, string Ephemeral);
    }
}
