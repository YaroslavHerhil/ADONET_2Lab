CREATE DATABASE Warehouse

USE Warehouse

CREATE TABLE Product(
	[Id] INT Primary key Identity(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[Type] NVARCHAR(MAX) NOT NULL,
	[Price] FLOAT NOT NULL,

)

CREATE TABLE Shipment(
	[Id] INT Primary key Identity(1,1),
	[Producer] NVARCHAR(MAX) NOT NULL,
	[Quantity] INT NOT NULL,
	[ShipmentDate] DATE NOT NULL,
)

ALTER TABLE Shipment
ADD CONSTRAINT FK_Shipment_Product FOREIGN KEY ([ProductId])
REFERENCES Product (Id);