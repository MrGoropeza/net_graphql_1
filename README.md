# .NET GraphQL 1

Mi primer proyecto de API GraphQL con .NET.

- Arquitectura: Clean Architecture
- Librerías:
  - HotChocolate para GraphQL
  - Entity Framework como ORM
  - HotChocolate.Data.EntityFramework para convertir fácilmente queries GraphQL en queries SQL
- Base de Datos: SQLite

## Comandos para la creación del proyecto

```bash
mkdir <solution_name>
dotnet new gitignore
dotnet new sln -n <solution_name>
dotnet new web --exclude-launch-settings -n API.GraphQL
dotnet sln add API.GraphQL

dotnet new classlib -n API.Domain
dotnet sln add API.Domain

dotnet new classlib -n API.Application
dotnet sln add API.Application
dotnet add API.Application reference API.Domain

dotnet new classlib -n API.Persistence
dotnet sln add API.Persistence
dotnet add API.Persistence reference API.Application

dotnet add API.GraphQL reference API.Application
dotnet add API.GraphQL reference API.Persistence

# Librerías
dotnet add API.Domain package Microsoft.Extensions.DependencyInjection
dotnet add API.GraphQL package HotChocolate.AspNetCore
dotnet add API.GraphQL package Microsoft.EntityFrameworkCore.Tools
dotnet add API.GraphQL package HotChocolate.Data.EntityFramework
dotnet add API.GraphQL package HotChocolate.Types.Analyzers
dotnet add API.Persistence package Microsoft.EntityFrameworkCore.Sqlite
```

## EF Migrations

```bash
# comando para crear una migration
dotnet ef migrations add <Migration-Name> -s API.GraphQL -p API.Persistence -o Migrations

# actualizar database con la definición los modelos
# o utilizar en caso de no tener creada la bdd
dotnet ef database update -s API.GraphQL -p API.Persistence
```

## Ejecutar Proyecto

```bash
dotnet watch --project API.GraphQL run --environment Development
```

Ir a la url http://localhost:5000/graphql
