# HospitalManagementSystem

## Dotnet and Winforms setup
### Visual Studio
Ensure you have the latest version of Visual Studio, preferably have Visual Studio Community 2026.

### Dotnet setup
Make sure you install Dotnet 10.0.0 on your machine to run the application.

## Setup MongoDB

### Create Server
Open MongoDB Compass and connect to:

mongodb://localhost:27017

Create a database named:

HospitalManagementDb

Create a collection named:

Users

The authentication system expects the following structure:

{
  "_id": ObjectId("..."),
  "Username": "admin",
  "Password": "password",
  "Role": "Admin"
}

### MongoDB Connection
The MongoDB connection string is configured in the server project's:

HospitalServer/appsettings.json

Example:

{
  "ConnectionStrings": {
    "MongoDb": "mongodb://localhost:27017"
  }
}

## Setup SQL Server Database
### Connecting to the Server in the application
The SQL Server connection string is located in `HospitalServer/appsettings.json`

Please change the string to whatever local database is compatible.

Current connection string:
`"SqlServer": "Server=(localdb)\\MSSQLLocalDB;Database=HospitalManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"`

### Creating database via migration
1. Open Tools --> NuGet Package Manager --> Package Manager Console
2. Set Default project to: HospitalServer
3. Run: `Update-Database`

### Updating database (optional, for devs)
1. Create a model class in HospitalServer/Models/
2. Update HospitalDbContext.cs using that model class
- This is where EFCore Migrations understand schema structure
3. Using the NuGet Package Manager Console run `Add-Migration <DescriptiveName>`
4. Using the NuGet Package Manager Console run `Update-Database`