using Foundation;
using G1.Stripe.Maui.Options;
using Stripe;

namespace G1.Stripe.Maui;

public class iOSPaymentSheet : IPaymentSheet
{
    public void Initialize(string publishableKey)
    {
        StripeCore.STPAPIClient.SharedClient.PublishableKey = publishableKey;
    }

    public async Task<PaymentSheetResult> Open(PaymentSheetOptions options, CancellationToken ct = default)
    {
        var tcs = new TaskCompletionSource<PaymentSheetResult>();
        using (ct.Register(() => tcs.TrySetCanceled(ct)))
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                // BuildPlatform reads UIScreen.MainScreen, which requires the UI thread.
                var configuration = options.BuildPlatform();
                var ps = new TSPSPaymentSheet(options.ClientSecret, configuration);
                ps.PresentFrom(Platform.GetCurrentUIViewController()!, (res, error) => OnPaymentSheetResult(res, error, tcs));
            }).ConfigureAwait(false);
            return await tcs.Task.ConfigureAwait(false);
        }
    }

    private void OnPaymentSheetResult(TSPSPaymentSheetResult paymentSheetResult, NSError? error, TaskCompletionSource<PaymentSheetResult> tcs)
    {

        switch (paymentSheetResult)
        {
            case TSPSPaymentSheetResult.Canceled:
                tcs.SetResult(new PaymentSheetResult.Canceled());
                break;

            case TSPSPaymentSheetResult.Failed:
                tcs.SetResult(new PaymentSheetResult.Failed(ToException(error)));
                break;

            case TSPSPaymentSheetResult.Completed:
                tcs.SetResult(new PaymentSheetResult.Completed());
                break;

            default:
                tcs.SetException(new ImpossiblePaymentSheetException("Result didnt match one of excpected cases"));
                break;

        }
    }

    private static Exception ToException(NSError? error)
    {
        return error is null 
            ? new ImpossiblePaymentSheetException("Internal error occured in stripe payment sheet") //should never be a case
            : new NSErrorException(error);
    }
}
