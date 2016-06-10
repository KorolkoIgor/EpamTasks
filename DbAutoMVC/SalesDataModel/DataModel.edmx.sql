
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/24/2016 00:00:27
-- Generated from EDMX file: D:\!Work\ИГОРЬ\EPAM\Study_2016\Task_4\DbAuto\SalesDataModel\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Finish];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SalesSet'
CREATE TABLE [dbo].[SalesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Cost] float  NOT NULL,
    [ManagerId] int  NOT NULL,
    [ClientId] int  NOT NULL,
    [GoodsId] int  NOT NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GoodsSet'
CREATE TABLE [dbo].[GoodsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [PK_SalesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GoodsSet'
ALTER TABLE [dbo].[GoodsSet]
ADD CONSTRAINT [PK_GoodsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ManagerId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_ManagerSales]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSales'
CREATE INDEX [IX_FK_ManagerSales]
ON [dbo].[SalesSet]
    ([ManagerId]);
GO

-- Creating foreign key on [ClientId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_ClientSales]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[ClientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSales'
CREATE INDEX [IX_FK_ClientSales]
ON [dbo].[SalesSet]
    ([ClientId]);
GO

-- Creating foreign key on [GoodsId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_GoodsSales]
    FOREIGN KEY ([GoodsId])
    REFERENCES [dbo].[GoodsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsSales'
CREATE INDEX [IX_FK_GoodsSales]
ON [dbo].[SalesSet]
    ([GoodsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------