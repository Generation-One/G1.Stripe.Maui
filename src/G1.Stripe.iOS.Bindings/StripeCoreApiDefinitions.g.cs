using Foundation;
using ObjCRuntime;
using PassKit;
using StripeCore;

namespace StripeCore
{
    // @interface STPAPIClient
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "_TtC10StripeCore12STPAPIClient")]
    interface STPAPIClient
	{
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull STPSDKVersion;
		[Static]
		[Export ("STPSDKVersion")]
		string STPSDKVersion { get; }

		// @property (readonly, nonatomic, strong, class) STPAPIClient * _Nonnull sharedClient;
		[Static]
		[Export ("sharedClient", ArgumentSemantic.Strong)]
		STPAPIClient SharedClient { get; }

		// @property (copy, nonatomic) NSString * _Nullable publishableKey;
		[NullAllowed, Export ("publishableKey")]
		string PublishableKey { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable stripeAccount;
		[NullAllowed, Export ("stripeAccount")]
		string StripeAccount { get; set; }

		// @property (nonatomic, strong) STPAppInfo * _Nullable appInfo;
		[NullAllowed, Export ("appInfo", ArgumentSemantic.Strong)]
		STPAppInfo AppInfo { get; set; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull apiVersion;
		[Static]
		[Export ("apiVersion")]
		string ApiVersion { get; }

		// -(instancetype _Nonnull)initWithPublishableKey:(NSString * _Nonnull)publishableKey;
		[Export ("initWithPublishableKey:")]
		NativeHandle Constructor (string publishableKey);
	}

	// @interface STPAppInfo
	[DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "_TtC10StripeCore10STPAppInfo")]
    interface STPAppInfo
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name partnerId:(NSString * _Nullable)partnerId version:(NSString * _Nullable)version url:(NSString * _Nullable)url __attribute__((objc_designated_initializer));
		[Export ("initWithName:partnerId:version:url:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string name, [NullAllowed] string partnerId, [NullAllowed] string version, [NullAllowed] string url);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable partnerId;
		[NullAllowed, Export ("partnerId")]
		string PartnerId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable version;
		[NullAllowed, Export ("version")]
		string Version { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }
	}

    // @interface STPError
    [DisableDefaultCtor]
    [BaseType(typeof(NSObject), Name = "_TtC10StripeCore8STPError")]
    interface STPError
	{
		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull stripeDomain;
		[Static]
		[Export ("stripeDomain")]
		string StripeDomain { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull STPPaymentHandlerErrorDomain;
		[Static]
		[Export ("STPPaymentHandlerErrorDomain")]
		string STPPaymentHandlerErrorDomain { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull errorMessageKey;
		[Static]
		[Export ("errorMessageKey")]
		string ErrorMessageKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull hintKey;
		[Static]
		[Export ("hintKey")]
		string HintKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull cardErrorCodeKey;
		[Static]
		[Export ("cardErrorCodeKey")]
		string CardErrorCodeKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull errorParameterKey;
		[Static]
		[Export ("errorParameterKey")]
		string ErrorParameterKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull stripeErrorCodeKey;
		[Static]
		[Export ("stripeErrorCodeKey")]
		string StripeErrorCodeKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull stripeErrorTypeKey;
		[Static]
		[Export ("stripeErrorTypeKey")]
		string StripeErrorTypeKey { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull stripeDeclineCodeKey;
		[Static]
		[Export ("stripeDeclineCodeKey")]
		string StripeDeclineCodeKey { get; }
	}
}
