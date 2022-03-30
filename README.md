# BookAGym
Gym Management and Booking Project.

# Deployed Website
The website has been deployed on and can be accessed by the following server IP.
http://35.225.88.69/

# Testing
The following contains instructions for accessing NUnit tests and GUI tests.
- **NUnit Testing** - The NUnit tests have been included under the Webservice.Tests project and can be run as a test suite using Visual Studio 2022.
- **Selenium Testing** - GUI tests have been included as the **401_GUI_tests.side** file inside root folder.

# Database Connection
The project has a temporary database linked to it with the access credentials. Should the database be down or gets corrupted, the database may be redeployed using the **GymDB.sql** file located in the root. The file contains a dump of the MySQL database as of March 29th, 2022.

# Build and Development Instructions

To run the project, open BookAGym.sln inside Visual Studio 2022 (for compatibility with ASP.NET CORE 6). Press the continue buttons from the top to compile and run the program. A webpage will be available under https://localhost:443 or http://localhost:80 which links to the project.

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

Testing Dependencies
- **NUnit** : NuGet Package for Internal ASP.NET Backend Unit Testing
- **Selenium** : Web Driver for GUI Based Unit Testing

For internal dependencies, right click Dependencies for a particular project and add the required dependencies.

# Providers Information
Currently implemented for a MySQL database with extensible support for other databases possible.
