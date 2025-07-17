using G1.Stripe.Maui;
using Stripe;

namespace G1.Stripe.Maui.Platforms.iOS;

public class iOSPaymentSheet : IPaymentSheet
{
    public void Initialize(string publishableKey)
    {
        StripeCore.STPAPIClient.SharedClient.PublishableKey = publishableKey;
    }

    public Task<PaymentSheetResult> Open(PaymentSheetOptions options)
    {
        var configuration = new TSPSConfiguration()
        {
            MerchantDisplayName = options.MerchantDisplayName,
        };

        if (!string.IsNullOrWhiteSpace(options.CustomerId) && !string.IsNullOrWhiteSpace(options.EphemeralKey))
        {
            configuration.Customer = new TSPSCustomerConfiguration(options.CustomerId, options.EphemeralKey);
        }

        var ps = new TSPSPaymentSheet(options.ClientSecret, configuration);


        var tcs = new TaskCompletionSource<PaymentSheetResult>();
        ps.PresentFrom(Platform.GetCurrentUIViewController(), (res, _) => OnPaymentSheetResult(res, tcs));
        return tcs.Task;
    }

    private void OnPaymentSheetResult(TSPSPaymentSheetResult paymentSheetResult, TaskCompletionSource<PaymentSheetResult> tcs)
    {

        switch (paymentSheetResult)
        {
            case TSPSPaymentSheetResult.Canceled:
                tcs.SetResult(new PaymentSheetResult.Canceled());
                break;

            case TSPSPaymentSheetResult.Failed:
                tcs.SetResult(new PaymentSheetResult.Failed(new NotImplementedException("Some internal error occured in stripe payment sheet")));
                break;

            case TSPSPaymentSheetResult.Completed:
                tcs.SetResult(new PaymentSheetResult.Completed());
                break;

            default:
                tcs.SetException(new ImpossiblePaymentSheetException("Result didnt match one of excpected cases"));
                break;

        }
    }
}
