# Application Server

This is a webserver on .NET 8.0 that links to a database. To run this, clone the repository, open the project in Visual Studio, and run it.

## Database

For the database, we are using a SQL Server database. The connection string has to be configured is in the `appsettings.json` file. You can change the connection string to your own database, by updating the `DefaultConnection` string in the file.

## Migrations

To add a new entity to the database, add the desired entity to the `Entities` folder as a new class. After that, update the Database Context in the `Data` folder (`DataContext.cs`) to include the new entity. 

After that, open the Package Manager Console in Visual Studio and run the following command:

```
Add-Migration <MigrationName>
```

This will create a new migration file in the `Migrations` folder. To apply the migration to the database, run the following command:

```
Update-Database
```

This will apply the migration to the database. If you want to revert the migration, you can run the following command:

```
Update-Database <MigrationName>
```

This will revert the migration to the specified migration. 

For any updates to the database, you can repeat the process of adding a new migration and updating the database.

## Adding a new Controller

To add a new controller, right-click on the `Controllers` folder and add a new controller. Make sure the desired controller is `API Controller - Empty`. This will create a new controller with the necessary boilerplate code.