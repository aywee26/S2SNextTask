# S2SNextTask
Simple ASP.NET Core Web API. Built as a solution of S2S Next entry task.

# Powered by
- [ASP.NET Core 6](https://github.com/dotnet/aspnetcore) - .NET Foundation and Contributors
- [Entity Framework Core 6](https://github.com/dotnet/efcore) - .NET Foundation and Contributors
- [MediatR](https://github.com/jbogard/MediatR) - Jimmy Bogard
- [GuardClauses](https://github.com/ardalis/GuardClauses) - Steve Smith
- [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) - Jason Taylor

# Getting started

1. Make sure .NET 6 SDK and SQL Server are installed

2. Set up database in SQL Server
     - Create user ```s2snext```
     - Create database ```s2snextdb``` and assign ```s2snext``` as an owner.

3. Clone the project

4. Apply migrations

```bash
cd .\S2SNextTask.Infrastructure
dotnet ef update database
```

5. Build the project

```bash
cd ..
dotnet build
```

6. Run the project

```bash
cd .\S2SNextTask.Presentation.WebAPI\
dotnet run
```

7. If project is built with Debugging purpose, Swagger UI will open for easier interaction. If it didn't open, go to:
```
https://localhost:7104/swagger/
```
You can use Postman or other REST Client to interact with this API.

# API Definition
## Get all books
Request:
```http
GET /api/Books/books
```
Response:
```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "author": "string",
    "title": "string",
    "publicationDate": "2022-08-11T21:10:00.000Z"
  }
]
```
## Search books
Request:
```http
GET /api/Books/search
```
Response:
```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "author": "string",
    "title": "string",
    "publicationDate": "2022-08-11T21:10:00.000Z"
  }
]
```
Acceptable parameters:
- ```?title={string}``` - filter results by Title
- ```?author={string}``` - filter results by Author
- ```?publicationDate={$date-time}``` - filter results by Date
- ```?order={Id|Title|Author|Date}``` - order results by Id (default), Title, Author or Date.
## Buy book
Request:
```http
POST /api/Books/books/{id}
```
Response:
```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "author": "string",
    "title": "string",
    "publicationDate": "2022-08-11T21:10:00.000Z"
  }
]
```

# Initial data
If there is no data present in ```dbo.Books``` table, initial data will be seeded when the project is started. You can change it by modifying the following class:

```
\S2SNextTask\S2SNextTask.Infrastructure\Persistence\AppDbContextInitializer.cs
```
# Licence
This project is licenced with the [MIT Licence](https://github.com/aywee26/S2SNextTask/blob/master/LICENSE.txt).
