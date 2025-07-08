using AndroidX.Activity;
using Com.Stripe.Android;
using Com.Stripe.Android.Paymentsheet;
using G1.Stripe.Maui;
using AndroidPaymentSheetResult = Com.Stripe.Android.Paymentsheet.PaymentSheetResult;
using SharedPSResult = G1.Stripe.Maui.PaymentSheetResult;

namespace G1.Stripe.Maui.Platforms.Android;

internal class AndroidPaymentSheet : IPaymentSheet
{
    internal static void CaptureActivity(ComponentActivity activity)
    {
        _sheet = new PaymentSheet.Builder(new ResultCallback()).Build(activity);
    }

    private static PaymentSheet _sheet;

    private static TaskCompletionSource<SharedPSResult>? _tcs;

    public void Initialize(string publishableKey)
    {
        PaymentConfiguration.Init(Platform.CurrentActivity, publishableKey);
    }

    public Task<SharedPSResult> Open(PaymentSheetOptions options)
    {
        var configurationBuilder = new PaymentSheet.Configuration.Builder(options.MerchantDisplayName) //todo Local One to DI
            .AllowsDelayedPaymentMethods(true); // Optional

        if (!string.IsNullOrWhiteSpace(options.CustomerId) && !string.IsNullOrWhiteSpace(options.EphemeralKey))
        {
            var customer = new PaymentSheet.CustomerConfiguration(options.CustomerId, options.EphemeralKey);
            configurationBuilder.Customer(customer);
        }

        var configuration = configurationBuilder.Build();
        _tcs = new TaskCompletionSource<SharedPSResult>();

        _sheet.PresentWithPaymentIntent(options.ClientSecret, configuration);

        return _tcs.Task;
    }

    private class ResultCallback : Java.Lang.Object, IPaymentSheetResultCallback
    {
        public void OnPaymentSheetResult(AndroidPaymentSheetResult paymentSheetResult)
        {
            switch (paymentSheetResult)
            {
                case AndroidPaymentSheetResult.Canceled c:
                    _tcs?.SetResult(SharedPSResult.Canceled);
                    break;

                case AndroidPaymentSheetResult.Failed f:
                    _tcs?.SetResult(SharedPSResult.Failed);
                    break;

                case AndroidPaymentSheetResult.Completed completed:
                    _tcs?.SetResult(SharedPSResult.Competed);
                    break;
                default:
                    _tcs?.SetException(new ImpossiblePaymentSheetException("Result didnt match one of excpected cases"));
                    break;
            }
        }
    }
}