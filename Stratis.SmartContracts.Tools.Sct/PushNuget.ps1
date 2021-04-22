rm "bin\release\" -Recurse -Force
dotnet pack --configuration Release  
dotnet nuget push bin\Release\Stratis.SmartContracts.Tools.Sct.*.nupkg -k -s https://api.nuget.org/v3/index.json