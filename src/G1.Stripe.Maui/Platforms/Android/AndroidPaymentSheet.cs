using AndroidX.Activity;
using Com.Stripe.Android;
using Com.Stripe.Android.Paymentsheet;
using AndroidPaymentSheetResult = Com.Stripe.Android.Paymentsheet.PaymentSheetResult;
using SharedPSResult = G1.Stripe.Maui.PaymentSheetResult;

namespace G1.Stripe.Maui.Platforms.Android;

public class AndroidPaymentSheet : IPaymentSheet
{
    internal static void CaptureActivity(ComponentActivity activity)
    {
        _capturedActivity = activity;
        _sheet = new PaymentSheet.Builder(new ResultCallback()).Build(activity);
    }

    private static ComponentActivity? _capturedActivity;

    private static PaymentSheet? _sheet;

    private static TaskCompletionSource<SharedPSResult>? _tcs;

    public void Initialize(string publishableKey)
    {
        ArgumentNullException.ThrowIfNull(_capturedActivity);
        PaymentConfiguration.Init(_capturedActivity, publishableKey);
    }

    public Task<SharedPSResult> Open(PaymentSheetOptions options)
    {
        ArgumentNullException.ThrowIfNull(_sheet);

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
                    _tcs?.SetResult(new PaymentSheetResult.Canceled());
                    break;

                case AndroidPaymentSheetResult.Failed f:
                    _tcs?.SetResult(new PaymentSheetResult.Failed(f.Error));
                    break;

                case AndroidPaymentSheetResult.Completed completed:
                    _tcs?.SetResult(new PaymentSheetResult.Completed());
                    break;
                default:
                    _tcs?.SetException(new ImpossiblePaymentSheetException("Result didnt match one of excpected cases"));
                    break;
            }
        }
    }
}