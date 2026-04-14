# Northwind Customers by City Console App

## Description

This is a C# console application that connects to a SQL Server database (Northwind) and allows the user to search for customers by city.

The program displays a list of all available cities, then prompts the user to enter a city name. It will then show all company names located in that city.

## Features

* Connects to SQL Server using a connection string
* Retrieves unique cities from the Customers table
* Prompts the user to enter a city
* Displays all company names in that city
* Handles errors using try-catch

## Technologies Used

* C#
* .NET Console Application
* Microsoft.Data.SqlClient
* SQL Server

## How to Run

1. Open the project folder in terminal
2. Install required package:

   ```
   dotnet add package Microsoft.Data.SqlClient
   ```
3. Build the project:

   ```
   dotnet build
   ```
4. Run the program:

   ```
   dotnet run
   ```

## Database Setup

Make sure you have a database named **Northwind**.

Create the Customers table using this SQL:

```
CREATE TABLE Customers (
    CustomerID NVARCHAR(5) PRIMARY KEY,
    CompanyName NVARCHAR(40),
    City NVARCHAR(15)
);

INSERT INTO Customers (CustomerID, CompanyName, City) VALUES
('AROUT', 'Around the Horn', 'London'),
('BSBEV', 'B''s Beverages', 'London'),
('CONSH', 'Consolidated Holdings', 'London'),
('EASTC', 'Eastern Connection', 'London'),
('NORTS', 'North/South', 'London'),
('SEVES', 'Seven Seas Imports', 'London');
```

## Example Output

```
Available cities:
London, Paris, Vancouver

Enter the name of a city: London

There are 6 customers in London:
Around the Horn
B's Beverages
Consolidated Holdings
Eastern Connection
North/South
Seven Seas Imports
```

## Notes

* Make sure your SQL Server name is correct in the connection string
* Example:

  ```
  Data Source=LAPTOP-DU6SRIJM;
  ```
* If you get "Invalid object name 'Customers'", create the table first

