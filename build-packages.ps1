$output = "./nupkgs"
$version = Get-Date -Format "MM.dd.yy.FFFFFF"

if ($null -ne $Env:NugetVersion){
    $version = $Env:NugetVersion
}
$projects = @()
$projects += "src\G1.Stripe.Android.Bindings\G1.Stripe.Android.Bindings.csproj"
$projects += "src\G1.Stripe.iOS.Bindings\G1.Stripe.iOS.Bindings.csproj"
$projects += "src\G1.Stripe.Maui\G1.Stripe.Maui.csproj"

Write-Host "Packages to publish"
Write-Host "--------------------------------------------------------"
Write-Host ($projects -join "`n")

dotnet restore
dotnet build --no-restore --configuration Release

if($LASTEXITCODE -ne 0)
{
    throw "dotnet build failed"
}

foreach ( $path in $projects ){
    dotnet pack $path `
        --output $output `
        --no-build `
        --configuration Release `
        -p:PackageVersion=$version `
        -p:IncludeSymbols=true `
        -p:SymbolPackageFormat=snupkg 
}