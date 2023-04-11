# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/nights.test.jacklescapefix/*" -Force -Recurse
dotnet publish "./nights.test.jacklescapefix.csproj" -c Release -o "$env:RELOADEDIIMODS/nights.test.jacklescapefix" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location