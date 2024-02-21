CREATE DATABASE Warehouse


USE [Warehouse]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Type]  NVARCHAR (MAX) NOT NULL,
    [Price] FLOAT (53)     NOT NULL
);



USE [Warehouse]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipment] (
    [ProductId]    INT            NOT NULL,
    [Producer]     NVARCHAR (MAX) NOT NULL,
    [Quantity]     INT            NOT NULL,
    [ShipmentDate] DATE           NOT NULL
);



