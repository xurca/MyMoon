## Enable Migrations

1. Install-Package Microsoft.EntityFrameworkCore.Tools
2. Add-Migration; Update-Database; Script-Migration;
3. [migrations tutorial pmc](https://www.learnentityframeworkcore.com/migrations/commands/pmc-commands) 
4. [migrations tutorial cli](https://www.learnentityframeworkcore.com/migrations/commands/cli-commands)

## Installation

1. [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)
2. dotnet-hosting-3.1.3-win
3. dotnet-sdk-3.1.201-win-x64
4. to create database run command **Update-Database** from Package Manager Console (pmc)
5. to create database run command **dotnet ef database update** from Command Line Interface (cli)

## Help

1. https://www.postgresqltutorial.com/
2. https://itnext.io/asp-net-core-3-1-entity-framework-core-with-postgresql-with-code-first-approach-33b102e1734f
3. https://www.youtube.com/watch?v=dK4Yb6-LxAk
4. https://github.com/jasontaylordev/CleanArchitecture
5. https://github.com/jasontaylordev/NorthwindTraders

## VSCode
- install [C# Extension for VS code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- `dotnet tool install --global dotnet-ef` from TERMINAL
- `dotnet ef Update-Database --project Api` from TERMINAL to run migrations and create database
- https://localhost:5001/swagger/index.html
- dotnet build
- dotnet run --project api