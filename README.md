# Planets

Simple .Net 8 + React Demo application

## pre-requisites

- Docker installed in local machine


## back-end

Consists in an API for managing CRUD operations using a Postgres database, can be run from the command line on a machine with dotnet cli installed.
The api depends on a postgres database that needs to be configured in the Appsettings.json file
The API needs a key, which can be a randomly generated string or uuid.
The appsetings.json file should look like the following.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Port=5432; User Id=<your-user>; Password=<your-pass>; Database=<databasename>"
  },
  "ApiKey": "<your-randon-api-key>"
}
```

## Running back-end

Start a postgress database just following the instructions in the official postgres image.
https://hub.docker.com/_/postgres                                                  

Navigate to the Api/Api path where you can find Api.csproj and run the command below.

```bash
dotnet run Api.csproj
```

If a proper connections string ios provided in appsetings.json the build will run the migrations to generate the database.


