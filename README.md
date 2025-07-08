# G1.Stripe.Maui

### G1.Stripe.Maui [![nuget](https://img.shields.io/nuget/v/G1.Stripe.Maui?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Maui)
### G1.Stripe.Android.Bindings [![nuget](https://img.shields.io/nuget/v/G1.Stripe.Android.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Android.Bindings)
### G1.Stripe.iOS.Bindings [![nuget](https://img.shields.io/nuget/v/G1.Stripe.iOS.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.iOS.Bindings)








A .NET MAUI library providing Stripe payment integration for cross-platform mobile applications.

## Stripe SDK Versions

This library uses the following Stripe SDK versions for each platform:

- **Stripe Android SDK**: `21.18.0`  
- **Stripe iOS SDK**: `24.16.1`

## Installation

In your MAUI project’s `MauiProgram.cs`, wire up the Payment Sheet under the `G1.Stripe.Maui` namespace:

```csharp
using G1.Stripe.Maui;

public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .UseStripePaymentSheet();

    return builder.Build();
}
```

## Usage

### 1. Initialize the SDK

Initialize with your Stripe publishable key:

```csharp
var paymentSheet = App.Current.Services.GetRequiredService<IPaymentSheet>();
paymentSheet.Initialize("pk_test_XXXXXXXXXXXXXXXXXXXXXXXX");
```

### 2. Present the Payment Sheet

Build your options and open the sheet:

```csharp
var options = new PaymentSheetOptions
{
    ClientSecret = paymentIntentClientSecret,
    MerchantDisplayName = "My Store, Inc.",
    EphemeralKey = ephemeralKey,
    CustomerId = customerId
};

var result = await paymentSheet.Open(options);
```

### 3. Handle the Result

```csharp
switch (result)
{
    case PaymentSheetResult.Completed:
        // Payment successful
        break;
    case PaymentSheetResult.Canceled:
        // User canceled the sheet
        break;
    case PaymentSheetResult.Failed:
        // An error occurred
        break;
}
```

## Important

If it doesn’t fit your needs:

### Register Yourself

Register \`AndroidPaymentSheet\` and \`iOSPaymentSheet\`. Make sure you call  
\`AndroidPaymentSheet.CaptureActivity(..)\` — Stripe requires an activity that is not yet started.

### Or Use Bindings Directly

Reference \`G1.Stripe.Android.Bindings\` and \`G1.Stripe.iOS.Bindings\` and consume the API from there.

#### Android

Android provides almost all APIs from Stripe.

#### iOS

For iOS, we have a very small set of APIs since Stripe doesn’t expose them via Objective-C. We need to wrap the necessary methods and then expose them to enable interop. I need help to expose more APIs. Details here: https://github.com/stripe/stripe-ios/issues/3377
