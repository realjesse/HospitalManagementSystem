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