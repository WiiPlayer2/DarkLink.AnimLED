#!/usr/bin/env pwsh
$ErrorActionPreference = 'Stop'
$ProjectName = 'DarkLink.AnimLED'

$now = [DateTime]::UtcNow
$versionSuffix = "pre$($now.ToString("yyyyMMddHHmmss"))"

New-Item ./output -ItemType Directory -Force | Out-Null
Remove-Item ./output/* -Recurse -Force | Out-Null
dotnet clean ./$ProjectName/$ProjectName.csproj `
    --configuration Release `
    --verbosity normal
dotnet build ./$ProjectName/$ProjectName.csproj `
    --configuration Release `
    --verbosity normal
dotnet pack ./$ProjectName/$ProjectName.csproj `
    --configuration Release `
    --version-suffix $versionSuffix `
    --output ./output `
    --verbosity minimal
