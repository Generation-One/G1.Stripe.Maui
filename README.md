# Stripe.Maui

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
### 3. Handle result

```csharp

switch (result)
{
    case PaymentSheetResult.Competed:
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
if it doesnt fit you
### Register yourself
Resgister `AndroidPaymentSheet` and `iOSPaymentSheet`. Make sure you call `AndroidPaymentSheet.CaptureActivity(..)` - stripe requered activity which is not STARTED

### Or use bindings directly
Reference `G1.Stripe.Android.Bindings` and `G1.Stripe.iOS.Bindings` and consume api from there.
#### Android
Androuid provides almost all api from stripe
#### iOS
For iOS we have really small amount of the api since stripe doesnt expose api via `-objc`.So we need to wrap all api and then expose, to be able to interop. I need help to expose more api. Details here: https://github.com/stripe/stripe-ios/issues/3377

