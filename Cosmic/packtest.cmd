
dotnet build -c Release
dotnet pack -c Release
dotnet tool uninstall --global cosmic
dotnet tool install --global --add-source ./nupkg cosmic
