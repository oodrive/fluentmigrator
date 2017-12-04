del src\FluentMigrator\bin\Release\*.nupkg
del src\FluentMigrator.Runner\bin\Release\*.nupkg
msbuild /t:pack /p:Configuration=Release src\FluentMigrator\FluentMigrator.csproj 
msbuild /t:pack /p:Configuration=Release src\FluentMigrator.Runner\FluentMigrator.Runner.csproj