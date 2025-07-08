#if ANDROID
using AndroidX.Activity;
using G1.Stripe.Maui.Platforms.Android;
using Microsoft.Maui.LifecycleEvents;
#endif

#if IOS
using G1.Stripe.Maui.Platforms.iOS;
#endif

namespace G1.Stripe.Maui;

public static class PaymentSheetDI
{
    public static MauiAppBuilder UseStripePaymentSheet(this MauiAppBuilder mauiAppBuilder)
    {
#if ANDROID
        mauiAppBuilder.ConfigureLifecycleEvents(builder =>
        {
            builder.AddAndroid(ab =>
            {
                ab.OnCreate((activity, bundle) =>
                {
                    if (activity is ComponentActivity ma)
                    {
                        AndroidPaymentSheet.CaptureActivity(ma);
                    }
                });
            });
        });
        mauiAppBuilder.Services.AddSingleton<IPaymentSheet, AndroidPaymentSheet>();
#elif IOS
        mauiAppBuilder.Services.AddSingleton<IPaymentSheet, iOSPaymentSheet>();
#endif
        return mauiAppBuilder;
    }
}
