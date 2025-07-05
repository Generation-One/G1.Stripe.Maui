# Makefile to rebuild Stripe and extract symbolgraphs using Swift 6.1.2

MODULE_NAME = Stripe.Swift.Proxy
SCHEME_NAME = Stripe.Swift.Proxy
XCODE_PROJECT_PATH = Stripe.Swift.Proxy
ARCHIVE_BASE_PATH = $(CURDIR)/obj
OUTPUT_PATH = $(CURDIR)/xcframework

LIB_VERSION = 24.16.1
XCODEBUILD = xcodebuild TOOLCHAINS=swift-6.1.2-RELEASE
SHARPIE_OUTPUT_PATH = $(CURDIR)/ApiDefinitions

.PHONY: build-ios build-simulator create-xcframework clean generate-api-definitions

all: build-ios build-simulator create-xcframework generate-api-definitions

build-ios:
	@echo "🛠 Building StripePaymentSheet without asset catalogs..."
	xcodebuild archive \
		-project $(XCODE_PROJECT_PATH)/Stripe.Swift.Proxy.xcodeproj \
		-scheme $(SCHEME_NAME) \
		-destination "generic/platform=iOS" \
		-configuration Release \
		-archivePath $(ARCHIVE_BASE_PATH)/Stripe.Swift.Proxy-ios \
		OTHER_SWIFT_FLAGS=-emit-objc-header \
		BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
		SKIP_INSTALL=NO \
		CLANG_ENABLE_MODULES=YES \
		INSTALL_GENERATED_HEADERS=YES \
		DEFINES_MODULE=YES

build-simulator:
	@echo "🛠 Building StripePaymentSheet without asset catalogs..."
	$(XCODEBUILD) archive \
		-project $(XCODE_PROJECT_PATH)/Stripe.Swift.Proxy.xcodeproj \
		-scheme $(SCHEME_NAME) \
		-sdk iphonesimulator \
		-configuration Release \
		-archivePath $(ARCHIVE_BASE_PATH)/Stripe.Swift.Proxy-simulator \
		BUILD_LIBRARY_FOR_DISTRIBUTION=YES \
		SKIP_INSTALL=NO

create-xcframework:
	$(XCODEBUILD) -create-xcframework \
		-framework $(ARCHIVE_BASE_PATH)/Stripe.Swift.Proxy-ios.xcarchive/Products/Library/Frameworks/Stripe_Swift_Proxy.framework \
		-framework $(ARCHIVE_BASE_PATH)/Stripe.Swift.Proxy-simulator.xcarchive/Products/Library/Frameworks/Stripe_Swift_Proxy.framework \
		-output $(OUTPUT_PATH)/Stripe.Swift.Proxy.xcframework

generate-api-definitions:
	sharpie bind \
		-output $(SHARPIE_OUTPUT_PATH) \
		-namespace StripeSwiftProxy \
		-sdk iphoneos \
		-scope xcframework/Stripe.Swift.Proxy.xcframework/ios-arm64/Stripe_Swift_Proxy.framework/Headers \
		xcframework/Stripe.Swift.Proxy.xcframework/ios-arm64/Stripe_Swift_Proxy.framework/Headers/Stripe_Swift_Proxy-Swift.h 

g-stripe-core:
	sharpie bind \
		-output $(SHARPIE_OUTPUT_PATH) \
		-namespace StripeSwiftProxy \
		-sdk iphoneos \
		-scope /Users/bym/Documents/libs/Stripe/StripeCore.xcframework/ios-arm64/StripeCore.framework/Headers \
		/Users/bym/Documents/libs/Stripe/StripeCore.xcframework/ios-arm64/StripeCore.framework/Headers/StripeCore-Swift.h 



clean:
	@echo "🧹 Cleaning up..."
	rm -rf $(ARCHIVE_BASE_PATH)
	rm -rf $(SHARPIE_OUTPUT_PATH)
