# SalesApi - Sales Management System

This project implements an API for sales management with ASP.NET Core 8, using DDD, SOLID practices and integration with Event Sending.

---

## Prerequisites

Before running the project, you will need to have installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (já incluído no .NET SDK)
- [PostgreSQL](https://www.postgresql.org/download/)

---

## Database Configuration

1. **Configure the connection string**:
	In the file `appsettings.Development.json`, configure the connection string to the PostgreSQL:
	```
	{
	  "ConnectionStrings": {
	    "DefaultConnection": "Host=localhost;Port=5432;Database=123vendas;Username=seu_usuario;Password=sua_senha"
	  }
	}
	```


2. **In your command prompt**:
	Navigate to the project root folder and run the following command:
	```
	dotnet ef database update -s .\SalesApi.Api -p .\SalesApi.Infrastructure
	```