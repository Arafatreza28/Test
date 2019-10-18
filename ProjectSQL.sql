create database BusinessManagement
use BusinessManagement

CREATE TABLE Category(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
)

CREATE TABLE Product
(
Id INT IDENTITY(1,1) PRIMARY KEY,
CategoryId INT REFERENCES Category (Id),
Code VARCHAR(50),
Name VARCHAR(50),
ReorderLevel VARCHAR(50),
[Description] VARCHAR(50),
)

--SELECT Code, Name, Name, ReorderLevel, [Description] FROM Product AS p
--LEFT JOIN Category AS c ON c.Id = p.Id 

CREATE TABLE Customer(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
[Address] VARCHAR(50),
Email VARCHAR(50),
Contact VARCHAR(50),
LoyalityPoint int,
)

CREATE TABLE Supplier(
Id INT IDENTITY(1,1)  PRIMARY KEY,
Code VARCHAR(50),
Name VARCHAR(50),
[Address] VARCHAR(50),
Email VARCHAR(50),
Contact VARCHAR(50),
ContactPerson VARCHAR(50),
)