# BookAGym
Gym Management and Booking Project.

To run the project, open BookAGym.sln inside Visual Studio 2022 (for compatibility with ASP.NET CORE 6). Press the continue buttons from the top to compile and run the program. A webpage will be available under https://localhost:7182 which links to the project.

In order to ensure a connection to a properly configured database, setup a database using the GymDB.sql file. Once the database is setup, point to it inside Webservice/appsettings.json inside the connection string in the following format
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Database": {
        "ConnectionString": "Server = {hostname}; Port = 3306; Database = GymDB; Uid = {username}; Pwd={password};"
  }
}
```
The included appsettings.json file includes a connection to a temporary database which was used during the development process, and is configured with the current version of the SQL schema.

# Dependencies
Uses Libraries available from NuGet.
- **MySQL.Data** 

For internal dependencies, right click Dependencies for a particular project and add the required dependencies.

# Backend Information
The following section includes important information and general guidelines for contributing to this project's backend.

# Frontend Information
The following section includes important information and general guidelines for contributing to this project's frontend.

# Providers Information
Currently implemented for a MySQL database with extensible support for other databases possible.

# API Information
Following is sample API calls and basic documentation

