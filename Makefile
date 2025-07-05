version=0.0.4-alpha
nugetSource = ""
apiKey = ""

all: full-ios full-android

full-android: build-stripe-android pack-stripe-android send-stripe-android
full-ios: build-stripe-android pack-stripe-android send-stripe-android

build-stripe-ios:
    dotnet build -c Release src\Stripe\Stripe.iOS.Bindings

build-stripe-android:
    dotnet build -c Release src\Stripe\Stripe.Android.Bindings

pack-stripe-ios:
    dotnet pack src\Stripe\Stripe.iOS.Bindings \
        --output output \
        --no-build \
        --configuration Release \
        -p:PackageVersion=$(version) \
        -p:IncludeSymbols=true \
        -p:SymbolPackageFormat=snupkg 

pack-stripe-android:
    dotnet pack src\Stripe\Stripe.Android.Bindings \
        --output output \
        --no-build \
        --configuration Release \
        -p:PackageVersion=$(version) \
        -p:IncludeSymbols=true \
        -p:SymbolPackageFormat=snupkg 

send-stripe-ios:
	dotnet nuget push "output\Stripe.iOS.Bindings.$(version).nupkg" --source $(nugetSource) --api-key $(apiKey)
	dotnet nuget push "output\Stripe.iOS.Bindings.$(version).snupkg" --source $(nugetSource) --api-key $(apiKey)

send-stripe-android:
	dotnet nuget push "output\Stripe.Android.Bindings.$(version).nupkg" --source $(nugetSource) --api-key $(apiKey)
	dotnet nuget push "output\Stripe.Android.Bindings.$(version).snupkg" --source $(nugetSource) --api-key $(apiKey)
