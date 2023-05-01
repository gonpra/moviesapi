## Getting Started with Postgresql branch
To use the postgresql branch, you'll need to have .NET 7 and Postgresql v13 installed on your system

1. Clone this repository to your local machine
2. Install the Entity Framework cli tool using ```dotnet tool install --global dotnet-ef```
3. Create a database named 'movies' on your postgresql instance
4. Update the database using the existing migrations with ```dotnet ef database update```
5. Build and run the project using ```dotnet run```