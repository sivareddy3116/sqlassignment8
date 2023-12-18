-- Create a new database
CREATE DATABASE Day8assDb;
GO

-- Use the newly created database
USE Day8assDb;
GO

-- Create a Products table
CREATE TABLE Products (
    PId CHAR(6) PRIMARY KEY,
    PName NVARCHAR(255) NOT NULL,
    PPrice DECIMAL(10, 2) NOT NULL,
    MnfDate DATE NOT NULL,
    ExpDate DATE NOT NULL
)

INSERT INTO Products (PId, PName, PPrice, MnfDate, ExpDate)
VALUES
    ('P00001', 'Expired Medicine', 19.99, '2023-01-01', '2024-01-01'),
    ('P00002', 'Stale Bread', 3.99, '2023-02-01', '2024-02-01'),
    ('P00003', 'Spoiled Milk', 2.50, '2023-03-01', '2024-03-01'),
    ('P00004', 'Rotten Fruit', 1.75, '2023-04-01', '2024-04-01'),
    ('P00005', 'Outdated Canned Food', 4.99, '2023-05-01', '2024-05-01'),
    ('P00006', 'Expired Yogurt', 2.99, '2023-06-01', '2024-06-01'),
    ('P00007', 'Moldy Cheese', 7.99, '2023-07-01', '2024-07-01'),
    ('P00008', 'Stale Chips', 1.75, '2023-08-01', '2024-08-01'),
    ('P00009', 'Old Cooking Oil', 5.99, '2023-09-01', '2024-09-01'),
    ('P00010', 'Expired Cosmetics', 12.50, '2023-10-01', '2024-10-01');
GO

select * from Products


