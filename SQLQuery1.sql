USE Northwind;
GO

CREATE TABLE Customers (
    CustomerID NVARCHAR(5) PRIMARY KEY,
    CompanyName NVARCHAR(40),
    City NVARCHAR(15)
);

INSERT INTO Customers (CustomerID, CompanyName, City) VALUES
('ALFKI', 'Alfreds Futterkiste', 'Berlin'),
('ANATR', 'Ana Trujillo Emparedados', 'México D.F.'),
('AROUT', 'Around the Horn', 'London'),
('BSBEV', 'B''s Beverages', 'London'),
('CONSH', 'Consolidated Holdings', 'London'),
('EASTC', 'Eastern Connection', 'London'),
('NORTS', 'North/South', 'London'),
('SEVES', 'Seven Seas Imports', 'London'),
('PARIS', 'Paris Specialties', 'Paris'),
('VANCO', 'Vancouver Delights', 'Vancouver');