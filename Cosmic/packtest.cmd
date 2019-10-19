
dotnet build -c Release
dotnet pack
dotnet tool uninstall --global cosmic
dotnet tool install --global --add-source ./nupkg cosmic
