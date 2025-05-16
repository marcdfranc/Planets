# Planets

Simple .Net 8 + React Demo application

## pre-requisites

- Docker installed in local machine


## back-end

It consists of an API for managing CRUD operations using a Postgres database. It can be run from the command line on a machine with the dotnet cli installed.
The API relies on a Postgres database that needs to be configured in the Appsettings.json file.
The API needs a key, which can be a randomly generated string or a UUID.
The appsettings.json file should look like this.

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


## running front-end

Create a .env.development file at the root of the web folder configuring the Api base Url and the API key to autjorize the APP.
See an exampple below.

```
REACT_APP_API_URL=http://localhost:5188/api
REACT_APP_API_KEY=<your-randon-api-key>
```

Use the terminal and navigate to the “/Web” folder and run the command.

```bash
npm start
```