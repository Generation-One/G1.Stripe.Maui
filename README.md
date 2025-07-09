# G1.Stripe.Maui
| | |
|---|---|
| [G1.Stripe.Maui](https://github.com/Generation-One/G1.Stripe.Maui/tree/master/src/G1.Stripe.Maui) | [![nuget](https://img.shields.io/nuget/v/G1.Stripe.Maui?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Maui) [![downloads](https://img.shields.io/nuget/dt/G1.Stripe.Maui?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Maui) |
| [G1.Stripe.Android.Bindings](https://github.com/Generation-One/G1.Stripe.Maui/tree/master/src/G1.Stripe.Android.Bindings) | [![nuget](https://img.shields.io/nuget/v/G1.Stripe.Android.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Android.Bindings) [![downloads](https://img.shields.io/nuget/dt/G1.Stripe.Android.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.Android.Bindings) |
| [G1.Stripe.iOS.Bindings](https://github.com/Generation-One/G1.Stripe.Maui/tree/master/src/G1.Stripe.iOS.Bindings) | [![nuget](https://img.shields.io/nuget/v/G1.Stripe.iOS.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.iOS.Bindings) [![downloads](https://img.shields.io/nuget/dt/G1.Stripe.iOS.Bindings?style=flat-square)](https://www.nuget.org/packages/G1.Stripe.iOS.Bindings) |

A .NET MAUI library providing Stripe payment integration for cross-platform mobile applications.

## Contribition

Maintaining this on our own isn’t feasible, so we’re turning it into a community-driven project. Right now it provides a minimal, working iOS API, but we need contributors to flesh it out and improve its reliability. We’ve seen many developers struggle with these same issues, so we’re making everything public in hopes that the community can help build a robust, well-documented solution together.

## Stripe SDK Versions

This library uses the following Stripe SDK versions for each platform:

- **Stripe Android SDK**: `21.18.0`  
- **Stripe iOS SDK**: `24.16.1`

## Long path error
You can face issue with long paths, similar to that:
```
Could not find a part of the path 'c:\packages\g1.stripe.ios.bindings\0.0.3-beta\lib\net9.0-ios18.0\G1.Stripe.iOS.Bindings.resources\Stripe.Swift.Proxy.xcframework\ios-arm64_x86_64-simulator\Stripe_Swift_Proxy.framework\Modules\Stripe_Swift_Proxy.swiftmodule\arm64-apple-ios-simulator.private.swiftinterface'.
```

to handle that need to [enable long paths support](https://learn.microsoft.com/en-us/answers/questions/1805411/how-to-enable-long-file-path-names-in-windows-11) and install package via CLI
```
dotnet add package G1.Stripe.Maui --prerelease
```

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

Register `AndroidPaymentSheet` and `iOSPaymentSheet`. Make sure you call  
`AndroidPaymentSheet.CaptureActivity(..)` — Stripe requires an activity that is not yet started.

### Or Use Bindings Directly

Reference `G1.Stripe.Android.Bindings` and `G1.Stripe.iOS.Bindings` and consume the API from there.

#### Android

Android provides almost all APIs from Stripe.

#### iOS

For iOS, we have a very small set of APIs since Stripe doesn’t expose them via Objective-C (`-objc`). We need to wrap the necessary methods and then expose them to enable interop. I need help to expose more APIs. Details here: https://github.com/stripe/stripe-ios/issues/3377
