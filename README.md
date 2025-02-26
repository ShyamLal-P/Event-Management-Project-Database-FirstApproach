# 🎉 Event Management Application

Welcome to the Event Management Application! This application is built with ASP.NET Core to help you manage events efficiently. It follows a database-first approach, where the database schema is created first, and the application code is generated based on the existing database.
## 📋 Table of Contents

- Setting Up `appsettings.json`
- Important Note
- Adding SQL Schemas in SSMS
- Running the Application
- Creating and Applying Migrations
- Troubleshooting

## 🛠️ Setting Up `appsettings.json`

Create a file named `appsettings.json` in the root directory of your project and add the following configuration:

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultConnection": "Server=<Add Your Connection String>;Database=EventManageCFA;Trusted_Connection=Yes;MultipleActiveResultSets=true;TrustServerCertificate=true"
    }
}
```
## ⚠️ Important Note

To ensure that your `appsettings.json` file, which contains sensitive information like your connection string, is not included in your Git repository, add it to your `.gitignore` file:

appsettings.json
appsettings.Development.json
🛠️ Adding SQL Schemas in SSMS
To manually create the database schema in SQL Server Management Studio (SSMS), follow these steps:

Open SSMS and connect to your SQL Server instance.

## 🆕💾Create a new database:
To manually create the database schema in SQL Server Management Studio (SSMS), follow these steps:

Open SSMS and connect to your SQL Server instance.

Create a new database:
```sh
CREATE DATABASE EventManagementDB;
```
Switch to the new database:
```sh
USE EventManagementDB;
```
Create the tables:

-- Create User table
```sh
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    ContactNumber BIGINT NOT NULL
);

-- Create Event table
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    Date DATE NOT NULL,
    OrganizerId INT NOT NULL,
    FOREIGN KEY (OrganizerId) REFERENCES Users(Id)
);

-- Create Ticket table
CREATE TABLE Tickets (
    TicketId INT PRIMARY KEY IDENTITY,
    EventId INT NOT NULL,
    UserId INT NOT NULL,
    BookingDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(Id) ON DELETE NO ACTION,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION
);

-- Create Notification table
CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    EventId INT NOT NULL,
    Message NVARCHAR(255) NOT NULL,
    SentTime TIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION,
    FOREIGN KEY (EventId) REFERENCES Events(Id) ON DELETE NO ACTION
);

-- Create Feedback table
CREATE TABLE Feedbacks (
    FeedbackId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    EventId INT NOT NULL,
    Rating INT NOT NULL,
    Comments NVARCHAR(255) NOT NULL,
    SubmittedTimestamp TIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION,
    FOREIGN KEY (EventId) REFERENCES Events(Id) ON DELETE NO ACTION
);
```
## 🚀 Running the Application

1. **Clone the repository**:
   ```sh
   git clone https://github.com/ShyamLal-P/Event-Management-Code-First-Approach
   ```
Navigate to the project directory:

```sh
cd EventManagementTrialCFA
```
Restore the dependencies:

```sh
dotnet restore
```
Apply the migrations to update the database:

```sh
dotnet ef database update
```
Run the application:

```sh
dotnet run
```
🛠️ Creating and Applying Migrations
Add a new migration:

```sh
dotnet ef migrations add <MigrationName>
```
Apply the migration to the database:

```sh
dotnet ef database update
```
## 🛠️ Troubleshooting

### Database Connection Issues
Ensure that your connection string in `appsettings.json` is correct and that your SQL Server instance is running.

### Migration Errors
If you encounter errors during migration, you may need to revert the migration and try again. Use the following commands:
```sh
dotnet ef migrations remove
```
```sh
dotnet ef migrations add <MigrationName>
```
```sh
dotnet ef database update
```
Feel free to reach out if you have any questions or need further assistance!

Happy coding! 🎉
