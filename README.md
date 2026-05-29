# CustomerApp – Customer Management System

A web-based customer management application built with ASP.NET Core MVC, Entity Framework 
Core and SQL Server. Developed as part of a practical assessment to demonstrate full-stack
.NET development skills.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Developer Questions](#developer-questions)
- [References](#references)

## Project Overview

CustomerApp is a two-page web application that allows users to manage customer records.
Users can add, edit, delete, and search for customers from a clean and responsive interface. All 
data is persisted to a SQL Server database using Entity Framework Core and queried using LINQ.

## Features

- View all customers in a sortable, paginated table (10 entries per page)
- Filter customers by name or VAT number
- Add new customers with full form validation
- Edit existing customer information
- Delete customers with a confirmation prompt before the delete is performed
- Required field validation (Name and Address)
- Email format validation on the contact person email field
- Success and error feedback messages after every action

## Technologies Used

| Technology | Purpose |
|------------|---------|
| ASP.NET Core MVC (.NET 8) | Web framework |
| Entity Framework Core 8 | ORM / database access |
| LINQ | Querying the database |
| SQL Server / LocalDB | Database |
| Bootstrap 5.3 | UI styling and layout |
| Bootstrap Icons | Icon library |
| jQuery Validation | Client-side form validation |
| C# | Application logic |

## Prerequisites

- VS Code with the ASP.NET and web development workload
- .NET 8 SDK
- SQL Server, SQL Server Express, or LocalDB 
- SQL Server Management Studio (SSMS)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/CustomerApp.git
cd CustomerApp
```
### 2. Install Dependencies

```bash
cd CustomerApp.Web
dotnet restore
```
### 3. Configure the Connection String

Open appsettings.json and update the connection string to match your SQL Server instance:
```bash
{
  "ConnectionStrings": {
    "CustomerApp_DB": "Server=(localdb)\\mssqllocaldb;Database=CustomerApp_DB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
Note: If you are using SQL Server Express, change the Server value to: Server=.\\SQLEXPRESS

## Database Setup

### Step 1 – Create the Database

Open SSMS or Visual Studio SQL Server Object Explorer, connect to your server, and run:

sql
CREATE DATABASE CustomerApp_DB;

### Step 2 – Create the Table
sql
USE CustomerApp_DB;

CREATE TABLE Customers (
    Id                 INT           PRIMARY KEY IDENTITY(1,1),
    Name               NVARCHAR(200) NOT NULL,
    Address            NVARCHAR(500) NOT NULL,
    TelephoneNumber    NVARCHAR(50)  NULL,
    ContactPersonName  NVARCHAR(200) NULL,
    ContactPersonEmail NVARCHAR(254) NULL,
    VATNumber          NVARCHAR(50)  NULL,
    CreatedAt          DATETIME2     NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt          DATETIME2     NOT NULL DEFAULT GETUTCDATE()
);

### Step 3 – Seed Test Data (Optional)
sql
INSERT INTO Customers (Name, Address, TelephoneNumber, ContactPersonName, ContactPersonEmail, VATNumber)
VALUES
    ('Acme Corp',     '123 Main St, Johannesburg', '011 555 0100', 'John Smith',   'john@acme.co.za',  '4510101234'),
    ('Beta Supplies', '45 Park Ave, Cape Town',    '021 555 0200', 'Jane Doe',     'jane@beta.co.za',  '4610201234'),
    ('Gamma Tech',    '77 Tech Road, Durban',      '031 555 0300', 'Mike Johnson', 'mike@gamma.co.za', '4710301234');

SELECT * FROM Customers;

## Running the Application

```bash
# 1. Clone and enter directory
git clone https://github.com/YOUR_USERNAME/CustomerApp.git
cd CustomerApp

# 2. Open in VS Code
code .

# 3. Restore and run
dotnet restore
dotnet run --project CustomerApp.Web

# 4. Open https://localhost:5001
```

## Project Structure
text
CustomerApp.Web/
├── Controllers/
│   └── CustomerController.cs       # All CRUD actions with LINQ queries 
├── Models/
│   ├── Customer.cs                 # Entity model with validation attributes
│   └── CustomerListViewModel.cs   # View model for list page (paging/sorting/filtering)
│   └── CustomerAppDbContext.cs     # Entity Framework Core DbContext
├── Views/
│   ├── Customer/
│   │   ├── Index.cshtml            # Customer list, filter, sort, paging, delete modal
│   │   ├── Create.cshtml           # Add new customer form
│   │   └── Edit.cshtml             # Edit existing customer form
│   └── Shared/
│       ├── _Layout.cshtml          # Shared page layout and navbar
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   └── css/
│       └── site.css
├── appsettings.json                # Database connection string
└── Program.cs                      # App startup and dependency injection

## References
### Microsoft Documentation
Microsoft. (2024). ASP.NET Core MVC Overview. https://learn.microsoft.com/en-us/aspnet/core/mvc/overview

Microsoft. (2024). Entity Framework Core - Getting Started. https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app

Microsoft. (2024). Scaffolding a DbContext and Models. https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding

Microsoft. (2024). Connection Strings in Entity Framework Core. https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings

Microsoft. (2024). Model Validation in ASP.NET Core MVC. https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation

Microsoft. (2024). Tag Helpers in ASP.NET Core. https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro

Microsoft. (2024). Dependency Injection in ASP.NET Core. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection

Microsoft. (2024). TempData in ASP.NET Core MVC. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state#tempdata

Microsoft. (2024). Introduction to LINQ Queries. https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries

Microsoft. (2024). Routing in ASP.NET Core. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing

Microsoft. (2024). Anti-forgery Tokens in ASP.NET Core. https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery

Microsoft. (2024). Configuration in ASP.NET Core. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration

### Bootstrap & jQuery
Bootstrap. (2024). *Bootstrap 5.3 - Introduction*. https://getbootstrap.com/docs/5.3/getting-started/introduction

Bootstrap. (2024). *Bootstrap 5.3 - Modal Component*. https://getbootstrap.com/docs/5.3/components/modal

Bootstrap. (2024). *Bootstrap 5.3 - Tables*. https://getbootstrap.com/docs/5.3/content/tables

Bootstrap. (2024). *Bootstrap 5.3 - Forms*. https://getbootstrap.com/docs/5.3/forms/overview

Bootstrap. (2024). *Bootstrap 5.3 - Alerts*. https://getbootstrap.com/docs/5.3/components/alerts

Bootstrap. (2024). *Bootstrap 5.3 - Navbar*. https://getbootstrap.com/docs/5.3/components/navbar

Bootstrap. (2024). *Bootstrap 5.3 - Pagination*. https://getbootstrap.com/docs/5.3/components/pagination

jQuery. (2024). jQuery API Documentation. https://api.jquery.com

jsDelivr. (2024). Bootstrap 5.3.2 CSS CDN. https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css

jsDelivr. (2024). Bootstrap Icons 1.11.3 CDN. https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css

jsDelivr. (2024). jQuery 3.7.1 CDN. https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.min.js

jsDelivr. (2024). jQuery Validation 1.20.0 CDN. https://cdn.jsdelivr.net/npm/jquery-validation@1.20.0/dist/jquery.validate.min.js

jsDelivr. (2024). jQuery Validation Unobtrusive 4.0.0 CDN. https://cdn.jsdelivr.net/npm/jquery-validation-unobtrusive@4.0.0/dist/jquery.validate.unobtrusive.min.js

--- 

## Author
Anelisa Mkhize
