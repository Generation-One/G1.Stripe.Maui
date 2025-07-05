using System;
using Foundation;
using ObjCRuntime;
using Stripe;
using StripeCore;
using UIKit;

namespace Stripe
{
    // @interface TSPAddressDetails
    [BaseType(typeof(NSObject))]
    interface TSPAddressDetails
	{
		// @property (copy, nonatomic) NSString * _Nullable line1;
		[NullAllowed, Export ("line1")]
		string Line1 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable line2;
		[NullAllowed, Export ("line2")]
		string Line2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable city;
		[NullAllowed, Export ("city")]
		string City { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export ("state")]
		string State { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export ("country")]
		string Country { get; set; }

		// -(instancetype _Nonnull)initWithLine1:(NSString * _Nullable)line1 line2:(NSString * _Nullable)line2 city:(NSString * _Nullable)city state:(NSString * _Nullable)state postalCode:(NSString * _Nullable)postalCode country:(NSString * _Nullable)country __attribute__((objc_designated_initializer));
		[Export ("initWithLine1:line2:city:state:postalCode:country:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] string line1, [NullAllowed] string line2, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string postalCode, [NullAllowed] string country);
	}

    // @interface TSPBillingDetails
    [BaseType(typeof(NSObject))]
    interface TSPBillingDetails
	{
		// @property (nonatomic, strong) TSPAddressDetails * _Nullable address;
		[NullAllowed, Export ("address", ArgumentSemantic.Strong)]
		TSPAddressDetails Address { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export ("phone")]
		string Phone { get; set; }

		// -(instancetype _Nonnull)initWithAddress:(TSPAddressDetails * _Nullable)address email:(NSString * _Nullable)email name:(NSString * _Nullable)name phone:(NSString * _Nullable)phone __attribute__((objc_designated_initializer));
		[Export ("initWithAddress:email:name:phone:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] TSPAddressDetails address, [NullAllowed] string email, [NullAllowed] string name, [NullAllowed] string phone);
	}

    // @interface TSPSAppearance
    [BaseType(typeof(NSObject))]
    interface TSPSAppearance
	{
		// @property (readonly, getter = default, nonatomic, strong, class) TSPSAppearance * _Nonnull default_;
		[Static]
		[Export ("default_", ArgumentSemantic.Strong)]
		TSPSAppearance Default_ { [Bind ("default")] get; }

		// @property (readonly, nonatomic, strong) TSPSAppearanceFont * _Nonnull font;
		[Export ("font", ArgumentSemantic.Strong)]
		TSPSAppearanceFont Font { get; }

		// @property (readonly, nonatomic, strong) TSPSAppearanceColors * _Nonnull colors;
		[Export ("colors", ArgumentSemantic.Strong)]
		TSPSAppearanceColors Colors { get; }

		// @property (readonly, nonatomic, strong) TSPSAppearancePrimaryButton * _Nonnull primaryButton;
		[Export ("primaryButton", ArgumentSemantic.Strong)]
		TSPSAppearancePrimaryButton PrimaryButton { get; }

		// @property (nonatomic) int cornerRadius;
		[Export ("cornerRadius")]
		int CornerRadius { get; set; }

		// @property (nonatomic) int borderWidth;
		[Export ("borderWidth")]
		int BorderWidth { get; set; }

		// @property (readonly, nonatomic, strong) TSPSAppearanceShadow * _Nonnull shadow;
		[Export ("shadow", ArgumentSemantic.Strong)]
		TSPSAppearanceShadow Shadow { get; }
	}

    // @interface TSPSAppearanceColors
    [BaseType(typeof(NSObject))]
    interface TSPSAppearanceColors
	{
		// @property (nonatomic, strong) UIColor * _Nullable primary;
		[NullAllowed, Export ("primary", ArgumentSemantic.Strong)]
		UIColor Primary { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable background;
		[NullAllowed, Export ("background", ArgumentSemantic.Strong)]
		UIColor Background { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable componentBackground;
		[NullAllowed, Export ("componentBackground", ArgumentSemantic.Strong)]
		UIColor ComponentBackground { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable componentBorder;
		[NullAllowed, Export ("componentBorder", ArgumentSemantic.Strong)]
		UIColor ComponentBorder { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable componentDivider;
		[NullAllowed, Export ("componentDivider", ArgumentSemantic.Strong)]
		UIColor ComponentDivider { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable text;
		[NullAllowed, Export ("text", ArgumentSemantic.Strong)]
		UIColor Text { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable textSecondary;
		[NullAllowed, Export ("textSecondary", ArgumentSemantic.Strong)]
		UIColor TextSecondary { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable componentText;
		[NullAllowed, Export ("componentText", ArgumentSemantic.Strong)]
		UIColor ComponentText { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable componentPlaceholderText;
		[NullAllowed, Export ("componentPlaceholderText", ArgumentSemantic.Strong)]
		UIColor ComponentPlaceholderText { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable icon;
		[NullAllowed, Export ("icon", ArgumentSemantic.Strong)]
		UIColor Icon { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable danger;
		[NullAllowed, Export ("danger", ArgumentSemantic.Strong)]
		UIColor Danger { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable warning;
		[NullAllowed, Export ("warning", ArgumentSemantic.Strong)]
		UIColor Warning { get; set; }
	}

    // @interface TSPSAppearanceFont
    [BaseType(typeof(NSObject))]
    interface TSPSAppearanceFont
	{
		// @property (nonatomic, strong) UIFont * _Nullable base;
		[NullAllowed, Export ("base", ArgumentSemantic.Strong)]
		UIFont Base { get; set; }

		// @property (nonatomic) int sizeScaleFactor;
		[Export ("sizeScaleFactor")]
		int SizeScaleFactor { get; set; }
	}

    // @interface TSPSAppearancePrimaryButton
    [BaseType(typeof(NSObject))]
    interface TSPSAppearancePrimaryButton
	{
		// @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
		[NullAllowed, Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable textColor;
		[NullAllowed, Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic) int cornerRadius;
		[Export ("cornerRadius")]
		int CornerRadius { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable borderColor;
		[NullAllowed, Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic) int borderWidth;
		[Export ("borderWidth")]
		int BorderWidth { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable font;
		[NullAllowed, Export ("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (readonly, nonatomic, strong) TSPSAppearanceShadow * _Nonnull shadow;
		[Export ("shadow", ArgumentSemantic.Strong)]
		TSPSAppearanceShadow Shadow { get; }
	}

    // @interface TSPSAppearanceShadow
    [BaseType(typeof(NSObject))]
    interface TSPSAppearanceShadow
	{
		// @property (nonatomic, strong) UIColor * _Nullable color;
		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		// @property (nonatomic) int opacity;
		[Export ("opacity")]
		int Opacity { get; set; }

		// @property (nonatomic) int offset;
		[Export ("offset")]
		int Offset { get; set; }

		// @property (nonatomic) int radius;
		[Export ("radius")]
		int Radius { get; set; }
	}

	// @interface TSPSApplePayConfiguration
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSApplePayConfiguration
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull merchantId;
		[Export ("merchantId")]
		string MerchantId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull merchantCountryCode;
		[Export ("merchantCountryCode")]
		string MerchantCountryCode { get; }

		// @property (readonly, nonatomic) int buttonType;
		[Export ("buttonType")]
		int ButtonType { get; }

		// @property (readonly, nonatomic, strong) TSPSApplePayConfigurationHandlers * _Nullable customHandlers;
		[NullAllowed, Export ("customHandlers", ArgumentSemantic.Strong)]
		TSPSApplePayConfigurationHandlers CustomHandlers { get; }

		// -(instancetype _Nonnull)initWithMerchantId:(NSString * _Nonnull)merchantId merchantCountryCode:(NSString * _Nonnull)merchantCountryCode buttonType:(id)buttonType paymentSummaryItems:(id)paymentSummaryItems customHandlers:(TSPSApplePayConfigurationHandlers * _Nullable)customHandlers __attribute__((objc_designated_initializer));
		[Export ("initWithMerchantId:merchantCountryCode:buttonType:paymentSummaryItems:customHandlers:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string merchantId, string merchantCountryCode, NSObject buttonType, NSObject paymentSummaryItems, [NullAllowed] TSPSApplePayConfigurationHandlers customHandlers);
	}

    // @interface TSPSApplePayConfigurationHandlers
    [BaseType(typeof(NSObject))]
    interface TSPSApplePayConfigurationHandlers
	{
	}

    // @interface TSPSConfiguration
    [BaseType(typeof(NSObject))]
    interface TSPSConfiguration
	{
		// @property (copy, nonatomic) NSString * _Nullable merchantDisplayName;
		[NullAllowed, Export ("merchantDisplayName")]
		string MerchantDisplayName { get; set; }

		// @property (nonatomic, strong) TSPSCustomerConfiguration * _Nullable customer;
		[NullAllowed, Export ("customer", ArgumentSemantic.Strong)]
		TSPSCustomerConfiguration Customer { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable primaryButtonColor;
		[NullAllowed, Export ("primaryButtonColor", ArgumentSemantic.Strong)]
		UIColor PrimaryButtonColor { get; set; }

		// @property (nonatomic, strong) TSPSAppearance * _Nonnull appearance;
		[Export ("appearance", ArgumentSemantic.Strong)]
		TSPSAppearance Appearance { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable returnURL;
		[NullAllowed, Export ("returnURL")]
		string ReturnURL { get; set; }

		// @property (nonatomic) int allowsDelayedPaymentMethods;
		[Export ("allowsDelayedPaymentMethods")]
		int AllowsDelayedPaymentMethods { get; set; }

		// @property (nonatomic) enum TSPSUserInterfaceStyle userInterfaceStyle;
		[Export ("userInterfaceStyle", ArgumentSemantic.Assign)]
		TSPSUserInterfaceStyle UserInterfaceStyle { get; set; }
	}

	// @interface TSPSCustomerConfiguration
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSCustomerConfiguration
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull id;
		[Export ("id")]
		string Id { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull ephemeralKeySecret;
		[Export ("ephemeralKeySecret")]
		string EphemeralKeySecret { get; }

		// -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id ephemeralKeySecret:(NSString * _Nonnull)ephemeralKeySecret __attribute__((objc_designated_initializer));
		[Export ("initWithId:ephemeralKeySecret:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string id, string ephemeralKeySecret);
	}

    // @interface TSPSPaymentButton
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentButton
	{
		// @property (copy, nonatomic) void (^ _Nullable)(TSPSPaymentOption * _Nullable) onPaymentOptionChanged;
		[NullAllowed, Export ("onPaymentOptionChanged", ArgumentSemantic.Copy)]
		Action<TSPSPaymentOption> OnPaymentOptionChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(enum TSPSPaymentSheetResult, int * _Nullable) onPaymentCompletion;
		[NullAllowed, Export ("onPaymentCompletion", ArgumentSemantic.Copy)]
		unsafe Action<TSPSPaymentSheetResult, IntPtr> OnPaymentCompletion { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(id)frame __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSObject frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		[Export ("initWithCoder:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSCoder coder);

		// -(void)configureWith:(TSPSPaymentSheetFlowController * _Nonnull)flowController;
		[Export ("configureWith:")]
		void ConfigureWith (TSPSPaymentSheetFlowController flowController);
	}

	// @interface TSPSPaymentIntent
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentIntent
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull stripeId;
		[Export ("stripeId")]
		string StripeId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull clientSecret;
		[Export ("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic, strong) int * _Nonnull amount;
		[Export ("amount", ArgumentSemantic.Strong)]
		unsafe IntPtr Amount { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull currency;
		[Export ("currency")]
		string Currency { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull status;
		[Export ("status")]
		string Status { get; }

		// @property (readonly, nonatomic, strong) TSPSPaymentMethod * _Nullable paymentMethod;
		[NullAllowed, Export ("paymentMethod", ArgumentSemantic.Strong)]
		TSPSPaymentMethod PaymentMethod { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull created;
		[Export ("created", ArgumentSemantic.Copy)]
		NSDate Created { get; }

		// @property (readonly, nonatomic) int liveMode;
		[Export ("liveMode")]
		int LiveMode { get; }
	}

	// @interface TSPSPaymentMethod
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentMethod
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull stripeId;
		[Export ("stripeId")]
		string StripeId { get; }

		// @property (readonly, nonatomic) enum TSPSPaymentMethodType type;
		[Export ("type")]
		TSPSPaymentMethodType Type { get; }

		// @property (readonly, nonatomic, strong) TSPBillingDetails * _Nullable billingDetails;
		[NullAllowed, Export ("billingDetails", ArgumentSemantic.Strong)]
		TSPBillingDetails BillingDetails { get; }

		// @property (readonly, nonatomic, strong) TSPSPaymentMethodCard * _Nullable card;
		[NullAllowed, Export ("card", ArgumentSemantic.Strong)]
		TSPSPaymentMethodCard Card { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable created;
		[NullAllowed, Export ("created", ArgumentSemantic.Copy)]
		NSDate Created { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable customerId;
		[NullAllowed, Export ("customerId")]
		string CustomerId { get; }

		// @property (readonly, nonatomic) int liveMode;
		[Export ("liveMode")]
		int LiveMode { get; }
	}

	// @interface TSPSPaymentMethodCard
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentMethodCard
	{
		// @property (readonly, nonatomic) enum TSPSCardBrand brand;
		[Export ("brand")]
		TSPSCardBrand Brand { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable last4;
		[NullAllowed, Export ("last4")]
		string Last4 { get; }

		// @property (readonly, nonatomic, strong) int * _Nullable expiryMonth;
		[NullAllowed, Export ("expiryMonth", ArgumentSemantic.Strong)]
		unsafe IntPtr ExpiryMonth { get; }

		// @property (readonly, nonatomic, strong) int * _Nullable expiryYear;
		[NullAllowed, Export ("expiryYear", ArgumentSemantic.Strong)]
		unsafe IntPtr ExpiryYear { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable funding;
		[NullAllowed, Export ("funding")]
		string Funding { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export ("country")]
		string Country { get; }
	}

	// @interface TSPSPaymentOption
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentOption
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull label;
		[Export ("label")]
		string Label { get; }

		// @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		// -(instancetype _Nonnull)initWithLabel:(NSString * _Nonnull)label image:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export ("initWithLabel:image:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string label, UIImage image);
	}

    // @interface TSPSPaymentSheet
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentSheet
	{
		// -(instancetype _Nonnull)initWithPaymentIntentClientSecret:(NSString * _Nonnull)paymentIntentClientSecret configuration:(TSPSConfiguration * _Nonnull)configuration;
		[Export ("initWithPaymentIntentClientSecret:configuration:")]
		NativeHandle Constructor (string paymentIntentClientSecret, TSPSConfiguration configuration);

		// +(void)resetCustomer;
		[Static]
		[Export ("resetCustomer")]
		void ResetCustomer ();

		// -(void)presentFrom:(UIViewController * _Nonnull)presentingViewController completion:(void (^ _Nonnull)(enum TSPSPaymentSheetResult, int * _Nullable))completion;
		[Export ("presentFrom:completion:")]
		unsafe void PresentFrom (UIViewController presentingViewController, Action<TSPSPaymentSheetResult, IntPtr> completion);
	}

    // @interface TSPSPaymentSheetFlowController
    [BaseType(typeof(NSObject))]
    interface TSPSPaymentSheetFlowController
	{
		// +(void)createWithPaymentIntentClientSecret:(NSString * _Nonnull)paymentIntentClientSecret configuration:(TSPSConfiguration * _Nonnull)configuration completion:(void (^ _Nonnull)(TSPSPaymentSheetFlowController * _Nullable, int * _Nullable))completion;
		[Static]
		[Export ("createWithPaymentIntentClientSecret:configuration:completion:")]
		unsafe void CreateWithPaymentIntentClientSecret (string paymentIntentClientSecret, TSPSConfiguration configuration, Action<TSPSPaymentSheetFlowController, IntPtr> completion);

		// +(void)createWithSetupIntentClientSecret:(NSString * _Nonnull)setupIntentClientSecret configuration:(TSPSConfiguration * _Nonnull)configuration completion:(void (^ _Nonnull)(TSPSPaymentSheetFlowController * _Nullable, int * _Nullable))completion;
		[Static]
		[Export ("createWithSetupIntentClientSecret:configuration:completion:")]
		unsafe void CreateWithSetupIntentClientSecret (string setupIntentClientSecret, TSPSConfiguration configuration, Action<TSPSPaymentSheetFlowController, IntPtr> completion);

		// -(void)presentPaymentOptionsFrom:(UIViewController * _Nonnull)presentingViewController completion:(void (^ _Nonnull)(void))completion;
		[Export ("presentPaymentOptionsFrom:completion:")]
		void PresentPaymentOptionsFrom (UIViewController presentingViewController, Action completion);

		// -(void)confirmFrom:(UIViewController * _Nonnull)presentingViewController completion:(void (^ _Nonnull)(enum TSPSPaymentSheetResult, int * _Nullable))completion;
		[Export ("confirmFrom:completion:")]
		unsafe void ConfirmFrom (UIViewController presentingViewController, Action<TSPSPaymentSheetResult, IntPtr> completion);
	}

	// @interface TSPSSetupIntent
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject))]
    interface TSPSSetupIntent
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull stripeId;
		[Export ("stripeId")]
		string StripeId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull clientSecret;
		[Export ("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull status;
		[Export ("status")]
		string Status { get; }

		// @property (readonly, nonatomic, strong) TSPSPaymentMethod * _Nullable paymentMethod;
		[NullAllowed, Export ("paymentMethod", ArgumentSemantic.Strong)]
		TSPSPaymentMethod PaymentMethod { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull created;
		[Export ("created", ArgumentSemantic.Copy)]
		NSDate Created { get; }

		// @property (readonly, nonatomic) int liveMode;
		[Export ("liveMode")]
		int LiveMode { get; }
	}
}
