# CustomerApp – Customer Management System

A web-based customer management application built with ASP.NET Core MVC, Entity Framework Core, and SQL Server. Developed as part of a practical assessment to demonstrate full-stack .NET development skills.

---

## Table of Contents

* [Project Overview](#project-overview)
* [Features](#features)
* [Technologies Used](#technologies-used)
* [Prerequisites](#prerequisites)
* [Getting Started](#getting-started)
* [Database Setup](#database-setup)
* [Running the Application](#running-the-application)
* [Project Structure](#project-structure)
* [References](#references)
* [Author](#author)

---

## Project Overview

CustomerApp is a customer management web application that allows users to manage customer records through a clean and responsive interface.

Users can:

* Add customers
* Edit customer information
* Delete customers
* Search and filter customer records
* View customers in a paginated table

All data is stored in SQL Server using Entity Framework Core and queried using LINQ.

---

## Features

### Customer Management

* View all customers in a sortable and paginated table
* Add new customer records
* Edit existing customer information
* Delete customer records with confirmation prompts

### Search & Filtering

* Filter customers by:

  * Customer name
  * VAT number

### Validation

* Required field validation for:

  * Name
  * Address
* Email format validation for contact person email

### User Experience

* Success and error feedback messages
* Responsive Bootstrap interface
* Clean and user-friendly layout

---

## Technologies Used

| Technology                | Purpose                |
| ------------------------- | ---------------------- |
| ASP.NET Core MVC (.NET 8) | Web framework          |
| Entity Framework Core 8   | ORM / Database access  |
| LINQ                      | Database querying      |
| SQL Server / LocalDB      | Database               |
| Bootstrap 5.3             | UI styling             |
| Bootstrap Icons           | Icon library           |
| jQuery Validation         | Client-side validation |
| C#                        | Application logic      |

---

## Prerequisites

Before running the application, ensure you have the following installed:

* .NET 8 SDK
* SQL Server, SQL Server Express, or LocalDB
* SQL Server Management Studio (SSMS)
* Visual Studio Code or Visual Studio

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/CustomerApp.git
cd CustomerApp
```

### 2. Restore Dependencies

```bash
cd CustomerApp.Web
dotnet restore
```

### 3. Configure the Connection String

Open `appsettings.json` and update the connection string:

```json
{
  "ConnectionStrings": {
    "CustomerApp_DB": "Server=(localdb)\\mssqllocaldb;Database=CustomerApp_DB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### SQL Server Express Example

```json
Server=.\\SQLEXPRESS
```

---

## Database Setup

### Step 1 – Create the Database

Open SSMS and run:

```sql
CREATE DATABASE CustomerApp_DB;
```

### Step 2 – Create the Customers Table

```sql
USE CustomerApp_DB;

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Address NVARCHAR(500) NOT NULL,
    TelephoneNumber NVARCHAR(50) NULL,
    ContactPersonName NVARCHAR(200) NULL,
    ContactPersonEmail NVARCHAR(254) NULL,
    VATNumber NVARCHAR(50) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);
```

### Step 3 – Seed Test Data (Optional)

```sql
INSERT INTO Customers (
    Name,
    Address,
    TelephoneNumber,
    ContactPersonName,
    ContactPersonEmail,
    VATNumber
)
VALUES
(
    'Acme Corp',
    '123 Main St, Johannesburg',
    '011 555 0100',
    'John Smith',
    'john@acme.co.za',
    '4510101234'
),
(
    'Beta Supplies',
    '45 Park Ave, Cape Town',
    '021 555 0200',
    'Jane Doe',
    'jane@beta.co.za',
    '4610201234'
),
(
    'Gamma Tech',
    '77 Tech Road, Durban',
    '031 555 0300',
    'Mike Johnson',
    'mike@gamma.co.za',
    '4710301234'
);

SELECT * FROM Customers;
```

---

## Running the Application

### Run the Project

```bash
# Clone the repository
git clone https://github.com/YOUR_USERNAME/CustomerApp.git

# Navigate to the project directory
cd CustomerApp

# Open in VS Code
code .

# Restore dependencies
dotnet restore

# Run the application
dotnet run --project CustomerApp.Web
```

### Open in Browser

```text
https://localhost:5001
```

---

## Project Structure

```text
CustomerApp.Web/
│
├── Controllers/
│   └── CustomerController.cs
│
├── Models/
│   ├── Customer.cs
│   ├── CustomerListViewModel.cs
│   └── CustomerAppDbContext.cs
│
├── Views/
│   ├── Customer/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   └── Edit.cshtml
│   │
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
│
├── wwwroot/
│   └── css/
│       └── site.css
│
├── appsettings.json
└── Program.cs
```
---

## Author

**Anelisa Mkhize**

