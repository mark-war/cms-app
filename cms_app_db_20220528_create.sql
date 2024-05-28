-- Check if the database exists
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'CMSDB')
BEGIN
    -- Create the database
    CREATE DATABASE CMSDB;
    PRINT 'Database CMSDB created successfully.';
END
ELSE
BEGIN
    PRINT 'Database CMSDB already exists.';
END
GO

-- Use the database
USE CMSDB;
GO

-- Check if the table exists
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Customers')
BEGIN
    -- Create the Customers table
    CREATE TABLE Customers (
        CustomerId INT PRIMARY KEY IDENTITY(1,1),
        FirstName NVARCHAR(100),
        LastName NVARCHAR(100),
        Email NVARCHAR(255) UNIQUE,
        Phone NVARCHAR(20),
        [Address] NVARCHAR(255)
    );
    PRINT 'Table Customers created successfully.';
END
ELSE
BEGIN
    PRINT 'Table Customers already exists.';
END
GO

-- Insert sample data
INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES
('Kobe', 'Bryant', 'kbryant@lakers.com', '123-456-7890', '824 Los Angeles California'),
('Michael', 'Jordan', 'mjordan@bulls.com', '456-789-0123', '2345 Illinois Chicago'),
('Earvin', 'Johnson', 'mjohnson@lakers.com', '789-012-3456', '789 Los Angeles California'),
('Stephen', 'Curry', 'scurry@warriors.com', '012-345-6789', '456 Golden State Bay Area'),
('Penny', 'Hardaway', 'phardaway@magic.com', '234-567-8901', '890 Orlando Colorado');
GO
