$artifacts = "./nupkgs"
$apiKey = $Env:NugetApiKey
$expectedCount = 6

$filenames = (Get-ChildItem -Path $artifacts | Select Name).Name

$actualCount = $filenames.Length

if($expectedCount -ne $actualCount)
{
    throw "Packages count is $expectedCount but actual count is $actualCount"
}

foreach($name in $filenames){
    dotnet nuget push ./nupkgs/$name --source https://api.nuget.org/v3/index.json --api-key $apiKey --skip-duplicate
}