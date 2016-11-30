
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2016 18:25:30
-- Generated from EDMX file: C:\Users\Public\Documents\NewPOS\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTransactionItem_tblProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransactionItem] DROP CONSTRAINT [FK_tblTransactionItem_tblProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTransactionItem_tblTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransactionItem] DROP CONSTRAINT [FK_tblTransactionItem_tblTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTransactionItem_tblUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTransactionItem] DROP CONSTRAINT [FK_tblTransactionItem_tblUsers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tblCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCategory];
GO
IF OBJECT_ID(N'[dbo].[tblCompanyDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCompanyDetails];
GO
IF OBJECT_ID(N'[dbo].[tblProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProduct];
GO
IF OBJECT_ID(N'[dbo].[tblTransaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTransaction];
GO
IF OBJECT_ID(N'[dbo].[tblTransactionItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTransactionItem];
GO
IF OBJECT_ID(N'[dbo].[tblUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblCategory'
CREATE TABLE [dbo].[tblCategory] (
    [categoryId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(50)  NULL,
    [categoryImage] varbinary(max)  NULL
);
GO

-- Creating table 'tblProduct'
CREATE TABLE [dbo].[tblProduct] (
    [productId] int IDENTITY(1,1) NOT NULL,
    [productName] nvarchar(50)  NULL,
    [productPrice] decimal(18,2)  NULL,
    [productImage] varbinary(max)  NULL,
    [categoryId] int  NULL
);
GO

-- Creating table 'tblTransaction'
CREATE TABLE [dbo].[tblTransaction] (
    [transactionId] int IDENTITY(1,1) NOT NULL,
    [transactionDate] datetime  NULL,
    [cashless] nchar(10)  NULL
);
GO

-- Creating table 'tblTransactionItem'
CREATE TABLE [dbo].[tblTransactionItem] (
    [transactionItemId] int IDENTITY(1,1) NOT NULL,
    [transactionId] int  NULL,
    [productId] int  NULL,
    [userId] int  NULL
);
GO

-- Creating table 'tblUsers'
CREATE TABLE [dbo].[tblUsers] (
    [userId] int IDENTITY(1,1) NOT NULL,
    [userName] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [name] nvarchar(50)  NULL,
    [surname] nvarchar(50)  NULL,
    [email] nvarchar(50)  NULL
);
GO

-- Creating table 'tblCompanyDetails'
CREATE TABLE [dbo].[tblCompanyDetails] (
    [Id] int  NOT NULL,
    [company_name] nchar(40)  NULL,
    [email] nchar(40)  NULL,
    [TaxPIN] nchar(15)  NULL,
    [Address] nchar(135)  NULL,
    [PhoneNumber] nchar(13)  NULL,
    [Logo] nchar(10)  NULL,
    [Country] nchar(10)  NULL,
    [swypecode] nchar(15)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [categoryId] in table 'tblCategory'
ALTER TABLE [dbo].[tblCategory]
ADD CONSTRAINT [PK_tblCategory]
    PRIMARY KEY CLUSTERED ([categoryId] ASC);
GO

-- Creating primary key on [productId] in table 'tblProduct'
ALTER TABLE [dbo].[tblProduct]
ADD CONSTRAINT [PK_tblProduct]
    PRIMARY KEY CLUSTERED ([productId] ASC);
GO

-- Creating primary key on [transactionId] in table 'tblTransaction'
ALTER TABLE [dbo].[tblTransaction]
ADD CONSTRAINT [PK_tblTransaction]
    PRIMARY KEY CLUSTERED ([transactionId] ASC);
GO

-- Creating primary key on [transactionItemId] in table 'tblTransactionItem'
ALTER TABLE [dbo].[tblTransactionItem]
ADD CONSTRAINT [PK_tblTransactionItem]
    PRIMARY KEY CLUSTERED ([transactionItemId] ASC);
GO

-- Creating primary key on [userId] in table 'tblUsers'
ALTER TABLE [dbo].[tblUsers]
ADD CONSTRAINT [PK_tblUsers]
    PRIMARY KEY CLUSTERED ([userId] ASC);
GO

-- Creating primary key on [Id] in table 'tblCompanyDetails'
ALTER TABLE [dbo].[tblCompanyDetails]
ADD CONSTRAINT [PK_tblCompanyDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [categoryId] in table 'tblProduct'
ALTER TABLE [dbo].[tblProduct]
ADD CONSTRAINT [FK_tblProduct_tblCategory]
    FOREIGN KEY ([categoryId])
    REFERENCES [dbo].[tblCategory]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProduct_tblCategory'
CREATE INDEX [IX_FK_tblProduct_tblCategory]
ON [dbo].[tblProduct]
    ([categoryId]);
GO

-- Creating foreign key on [productId] in table 'tblTransactionItem'
ALTER TABLE [dbo].[tblTransactionItem]
ADD CONSTRAINT [FK_tblTransactionItem_tblProduct]
    FOREIGN KEY ([productId])
    REFERENCES [dbo].[tblProduct]
        ([productId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTransactionItem_tblProduct'
CREATE INDEX [IX_FK_tblTransactionItem_tblProduct]
ON [dbo].[tblTransactionItem]
    ([productId]);
GO

-- Creating foreign key on [transactionId] in table 'tblTransactionItem'
ALTER TABLE [dbo].[tblTransactionItem]
ADD CONSTRAINT [FK_tblTransactionItem_tblTransaction]
    FOREIGN KEY ([transactionId])
    REFERENCES [dbo].[tblTransaction]
        ([transactionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTransactionItem_tblTransaction'
CREATE INDEX [IX_FK_tblTransactionItem_tblTransaction]
ON [dbo].[tblTransactionItem]
    ([transactionId]);
GO

-- Creating foreign key on [userId] in table 'tblTransactionItem'
ALTER TABLE [dbo].[tblTransactionItem]
ADD CONSTRAINT [FK_tblTransactionItem_tblUsers]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[tblUsers]
        ([userId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTransactionItem_tblUsers'
CREATE INDEX [IX_FK_tblTransactionItem_tblUsers]
ON [dbo].[tblTransactionItem]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------