
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2017 13:49:11
-- Generated from EDMX file: E:\MVC\Rapid\RapidLogisticsSolution\RapidLogistics Solution\DataModel\RapidSolutionDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RapidSolution];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__BoxInfo__Employe__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoxInfo] DROP CONSTRAINT [FK__BoxInfo__Employe__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__BoxInfo__MasterB__0CBAE877]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoxInfo] DROP CONSTRAINT [FK__BoxInfo__MasterB__0CBAE877];
GO
IF OBJECT_ID(N'[dbo].[FK__Employee__Wareho__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__Wareho__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__MasterBil__Emplo__398D8EEE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MasterBill] DROP CONSTRAINT [FK__MasterBil__Emplo__398D8EEE];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__BoxId__15502E78]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInfor] DROP CONSTRAINT [FK__ShipmentI__BoxId__15502E78];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__BoxId__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInforTemp] DROP CONSTRAINT [FK__ShipmentI__BoxId__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__Emplo__3B75D760]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInfor] DROP CONSTRAINT [FK__ShipmentI__Emplo__3B75D760];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__Emplo__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInforTemp] DROP CONSTRAINT [FK__ShipmentI__Emplo__46E78A0C];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__Wareh__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInfor] DROP CONSTRAINT [FK__ShipmentI__Wareh__5535A963];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentI__Wareh__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentInforTemp] DROP CONSTRAINT [FK__ShipmentI__Wareh__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__BoxId__1B0907CE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOut] DROP CONSTRAINT [FK__ShipmentO__BoxId__1B0907CE];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__BoxId__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOutTemp] DROP CONSTRAINT [FK__ShipmentO__BoxId__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Emplo__3C69FB99]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOut] DROP CONSTRAINT [FK__ShipmentO__Emplo__3C69FB99];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Emplo__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOutTemp] DROP CONSTRAINT [FK__ShipmentO__Emplo__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Maste__1BFD2C07]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOut] DROP CONSTRAINT [FK__ShipmentO__Maste__1BFD2C07];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Maste__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOutTemp] DROP CONSTRAINT [FK__ShipmentO__Maste__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Wareh__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOut] DROP CONSTRAINT [FK__ShipmentO__Wareh__5629CD9C];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentO__Wareh__5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentOutTemp] DROP CONSTRAINT [FK__ShipmentO__Wareh__5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__ShipmentW__Emplo__3D5E1FD2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipmentWaitToConfirm] DROP CONSTRAINT [FK__ShipmentW__Emplo__3D5E1FD2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BoxInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoxInfo];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[ErrorLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ErrorLog];
GO
IF OBJECT_ID(N'[dbo].[Manifest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Manifest];
GO
IF OBJECT_ID(N'[dbo].[MasterBill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MasterBill];
GO
IF OBJECT_ID(N'[dbo].[ShipmentInfor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipmentInfor];
GO
IF OBJECT_ID(N'[dbo].[ShipmentInforTemp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipmentInforTemp];
GO
IF OBJECT_ID(N'[dbo].[ShipmentOut]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipmentOut];
GO
IF OBJECT_ID(N'[dbo].[ShipmentOutTemp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipmentOutTemp];
GO
IF OBJECT_ID(N'[dbo].[ShipmentWaitToConfirm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipmentWaitToConfirm];
GO
IF OBJECT_ID(N'[dbo].[Warehouse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warehouse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ShipmentOuts'
CREATE TABLE [dbo].[ShipmentOuts] (
    [ShipmentId] varchar(100)  NOT NULL,
    [BoxIdRef] int  NULL,
    [MasterBillId] int  NULL,
    [DateOut] datetime  NULL,
    [BoxIdString] varchar(100)  NULL,
    [MasterBillIdString] varchar(100)  NULL,
    [EmployeeId] int  NULL,
    [WarehouseId] int  NULL,
    [IsSyncOms] bit  NULL,
    [DateCreated] datetime  NULL
);
GO

-- Creating table 'Manifests'
CREATE TABLE [dbo].[Manifests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SysDate] datetime  NULL,
    [Active] bit  NULL,
    [MasterAirWayBill] varchar(100)  NULL,
    [ShipmentNo] varchar(100)  NULL,
    [FlightNumber] varchar(50)  NULL,
    [FlightDate] varchar(50)  NULL,
    [BoxID] varchar(100)  NULL,
    [HSCode] varchar(100)  NULL,
    [ContactName] nvarchar(100)  NULL,
    [Tel] varchar(200)  NULL,
    [Address] nvarchar(1000)  NULL,
    [Currency] nvarchar(20)  NULL,
    [Content] nvarchar(1000)  NULL,
    [Quantity] int  NULL,
    [UnitPrice] float  NULL,
    [TotalValue] float  NULL,
    [Weight] float  NULL,
    [Original] nvarchar(100)  NULL,
    [Destination] nvarchar(100)  NULL,
    [Country] nvarchar(100)  NULL,
    [CompanyName] nvarchar(200)  NULL,
    [CreationDate] datetime  NULL,
    [DeclarationNo] varchar(15)  NULL
);
GO

-- Creating table 'ShipmentWaitToConfirms'
CREATE TABLE [dbo].[ShipmentWaitToConfirms] (
    [ShipmentId] varchar(100)  NOT NULL,
    [CreatedDate] datetime  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(150)  NULL,
    [UserName] nvarchar(150)  NULL,
    [Pasword] nvarchar(500)  NULL,
    [Role] nvarchar(100)  NULL,
    [DateCreated] datetime  NULL,
    [BirthDate] datetime  NULL,
    [Phone] varchar(30)  NULL,
    [Email] varchar(150)  NULL,
    [Address] nvarchar(200)  NULL,
    [Status] bit  NULL,
    [WarehouseId] int  NULL
);
GO

-- Creating table 'BoxInfoes'
CREATE TABLE [dbo].[BoxInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BoxId] varchar(100)  NULL,
    [DateCreated] datetime  NULL,
    [ShipmentQuantity] int  NULL,
    [MasterBillId] int  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'ShipmentInfors'
CREATE TABLE [dbo].[ShipmentInfors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShipmentId] varchar(100)  NULL,
    [DateCreated] datetime  NULL,
    [Sender] nvarchar(300)  NULL,
    [Receiver] nvarchar(300)  NULL,
    [TelReceiver] varchar(50)  NULL,
    [TotalValue] float  NULL,
    [Descrition] nvarchar(1000)  NULL,
    [BoxId] int  NULL,
    [Status] nvarchar(100)  NULL,
    [EmployeeId] int  NULL,
    [WarehouseId] int  NULL,
    [IsSyncOms] bit  NULL,
    [DeclarationNo] varchar(15)  NULL,
    [Country] nvarchar(100)  NULL,
    [Address] nvarchar(500)  NULL,
    [Consignee] nvarchar(200)  NULL,
    [Content] nvarchar(300)  NULL,
    [NumberPackage] int  NULL,
    [Weight] float  NULL,
    [DateOfCompletion] datetime  NULL
);
GO

-- Creating table 'MasterBills'
CREATE TABLE [dbo].[MasterBills] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MasterAirWayBill] varchar(100)  NULL,
    [DateCreated] datetime  NULL,
    [DateArrived] datetime  NULL,
    [EmployeeId] int  NULL
);
GO

-- Creating table 'ErrorLogs'
CREATE TABLE [dbo].[ErrorLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NULL,
    [AppCode] nvarchar(4000)  NULL,
    [ErrorCode] nvarchar(4000)  NULL,
    [ErrorMessage] nvarchar(max)  NULL
);
GO

-- Creating table 'ShipmentInforTemps'
CREATE TABLE [dbo].[ShipmentInforTemps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShipmentId] varchar(100)  NULL,
    [DateCreated] datetime  NULL,
    [Sender] nvarchar(300)  NULL,
    [Receiver] nvarchar(300)  NULL,
    [TelReceiver] varchar(50)  NULL,
    [TotalValue] float  NULL,
    [Descrition] nvarchar(1000)  NULL,
    [BoxId] int  NULL,
    [Weight] float  NULL,
    [Status] nvarchar(100)  NULL,
    [EmployeeId] int  NULL,
    [WarehouseId] int  NULL
);
GO

-- Creating table 'ShipmentOutTemps'
CREATE TABLE [dbo].[ShipmentOutTemps] (
    [ShipmentId] varchar(100)  NOT NULL,
    [BoxIdRef] int  NULL,
    [BoxIdString] varchar(100)  NULL,
    [MasterBillId] int  NULL,
    [MasterBillIdString] varchar(100)  NULL,
    [DateOut] datetime  NULL,
    [EmployeeId] int  NULL,
    [WarehouseId] int  NULL
);
GO

-- Creating table 'Warehouses'
CREATE TABLE [dbo].[Warehouses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdCode] varchar(50)  NULL,
    [Name] nvarchar(200)  NULL,
    [Location] nvarchar(500)  NULL,
    [Description] nvarchar(500)  NULL,
    [DateCreated] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ShipmentId] in table 'ShipmentOuts'
ALTER TABLE [dbo].[ShipmentOuts]
ADD CONSTRAINT [PK_ShipmentOuts]
    PRIMARY KEY CLUSTERED ([ShipmentId] ASC);
GO

-- Creating primary key on [Id] in table 'Manifests'
ALTER TABLE [dbo].[Manifests]
ADD CONSTRAINT [PK_Manifests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ShipmentId] in table 'ShipmentWaitToConfirms'
ALTER TABLE [dbo].[ShipmentWaitToConfirms]
ADD CONSTRAINT [PK_ShipmentWaitToConfirms]
    PRIMARY KEY CLUSTERED ([ShipmentId] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoxInfoes'
ALTER TABLE [dbo].[BoxInfoes]
ADD CONSTRAINT [PK_BoxInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShipmentInfors'
ALTER TABLE [dbo].[ShipmentInfors]
ADD CONSTRAINT [PK_ShipmentInfors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MasterBills'
ALTER TABLE [dbo].[MasterBills]
ADD CONSTRAINT [PK_MasterBills]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ErrorLogs'
ALTER TABLE [dbo].[ErrorLogs]
ADD CONSTRAINT [PK_ErrorLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShipmentInforTemps'
ALTER TABLE [dbo].[ShipmentInforTemps]
ADD CONSTRAINT [PK_ShipmentInforTemps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ShipmentId] in table 'ShipmentOutTemps'
ALTER TABLE [dbo].[ShipmentOutTemps]
ADD CONSTRAINT [PK_ShipmentOutTemps]
    PRIMARY KEY CLUSTERED ([ShipmentId] ASC);
GO

-- Creating primary key on [Id] in table 'Warehouses'
ALTER TABLE [dbo].[Warehouses]
ADD CONSTRAINT [PK_Warehouses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'ShipmentOuts'
ALTER TABLE [dbo].[ShipmentOuts]
ADD CONSTRAINT [FK__ShipmentO__Emplo__4316F928]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Emplo__4316F928'
CREATE INDEX [IX_FK__ShipmentO__Emplo__4316F928]
ON [dbo].[ShipmentOuts]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'ShipmentWaitToConfirms'
ALTER TABLE [dbo].[ShipmentWaitToConfirms]
ADD CONSTRAINT [FK__ShipmentW__Emplo__440B1D61]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentW__Emplo__440B1D61'
CREATE INDEX [IX_FK__ShipmentW__Emplo__440B1D61]
ON [dbo].[ShipmentWaitToConfirms]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'BoxInfoes'
ALTER TABLE [dbo].[BoxInfoes]
ADD CONSTRAINT [FK__BoxInfo__Employe__45F365D3]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__BoxInfo__Employe__45F365D3'
CREATE INDEX [IX_FK__BoxInfo__Employe__45F365D3]
ON [dbo].[BoxInfoes]
    ([EmployeeId]);
GO

-- Creating foreign key on [BoxId] in table 'ShipmentInfors'
ALTER TABLE [dbo].[ShipmentInfors]
ADD CONSTRAINT [FK__ShipmentI__BoxId__15502E78]
    FOREIGN KEY ([BoxId])
    REFERENCES [dbo].[BoxInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__BoxId__15502E78'
CREATE INDEX [IX_FK__ShipmentI__BoxId__15502E78]
ON [dbo].[ShipmentInfors]
    ([BoxId]);
GO

-- Creating foreign key on [BoxIdRef] in table 'ShipmentOuts'
ALTER TABLE [dbo].[ShipmentOuts]
ADD CONSTRAINT [FK__ShipmentO__BoxId__1B0907CE]
    FOREIGN KEY ([BoxIdRef])
    REFERENCES [dbo].[BoxInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__BoxId__1B0907CE'
CREATE INDEX [IX_FK__ShipmentO__BoxId__1B0907CE]
ON [dbo].[ShipmentOuts]
    ([BoxIdRef]);
GO

-- Creating foreign key on [EmployeeId] in table 'ShipmentInfors'
ALTER TABLE [dbo].[ShipmentInfors]
ADD CONSTRAINT [FK__ShipmentI__Emplo__44FF419A]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__Emplo__44FF419A'
CREATE INDEX [IX_FK__ShipmentI__Emplo__44FF419A]
ON [dbo].[ShipmentInfors]
    ([EmployeeId]);
GO

-- Creating foreign key on [MasterBillId] in table 'BoxInfoes'
ALTER TABLE [dbo].[BoxInfoes]
ADD CONSTRAINT [FK__BoxInfo__MasterB__0CBAE877]
    FOREIGN KEY ([MasterBillId])
    REFERENCES [dbo].[MasterBills]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__BoxInfo__MasterB__0CBAE877'
CREATE INDEX [IX_FK__BoxInfo__MasterB__0CBAE877]
ON [dbo].[BoxInfoes]
    ([MasterBillId]);
GO

-- Creating foreign key on [EmployeeId] in table 'MasterBills'
ALTER TABLE [dbo].[MasterBills]
ADD CONSTRAINT [FK__MasterBil__Emplo__46E78A0C]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MasterBil__Emplo__46E78A0C'
CREATE INDEX [IX_FK__MasterBil__Emplo__46E78A0C]
ON [dbo].[MasterBills]
    ([EmployeeId]);
GO

-- Creating foreign key on [MasterBillId] in table 'ShipmentOuts'
ALTER TABLE [dbo].[ShipmentOuts]
ADD CONSTRAINT [FK__ShipmentO__Maste__1BFD2C07]
    FOREIGN KEY ([MasterBillId])
    REFERENCES [dbo].[MasterBills]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Maste__1BFD2C07'
CREATE INDEX [IX_FK__ShipmentO__Maste__1BFD2C07]
ON [dbo].[ShipmentOuts]
    ([MasterBillId]);
GO

-- Creating foreign key on [BoxId] in table 'ShipmentInforTemps'
ALTER TABLE [dbo].[ShipmentInforTemps]
ADD CONSTRAINT [FK__ShipmentI__BoxId__5535A963]
    FOREIGN KEY ([BoxId])
    REFERENCES [dbo].[BoxInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__BoxId__5535A963'
CREATE INDEX [IX_FK__ShipmentI__BoxId__5535A963]
ON [dbo].[ShipmentInforTemps]
    ([BoxId]);
GO

-- Creating foreign key on [BoxIdRef] in table 'ShipmentOutTemps'
ALTER TABLE [dbo].[ShipmentOutTemps]
ADD CONSTRAINT [FK__ShipmentO__BoxId__59FA5E80]
    FOREIGN KEY ([BoxIdRef])
    REFERENCES [dbo].[BoxInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__BoxId__59FA5E80'
CREATE INDEX [IX_FK__ShipmentO__BoxId__59FA5E80]
ON [dbo].[ShipmentOutTemps]
    ([BoxIdRef]);
GO

-- Creating foreign key on [EmployeeId] in table 'ShipmentInforTemps'
ALTER TABLE [dbo].[ShipmentInforTemps]
ADD CONSTRAINT [FK__ShipmentI__Emplo__5629CD9C]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__Emplo__5629CD9C'
CREATE INDEX [IX_FK__ShipmentI__Emplo__5629CD9C]
ON [dbo].[ShipmentInforTemps]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'ShipmentOutTemps'
ALTER TABLE [dbo].[ShipmentOutTemps]
ADD CONSTRAINT [FK__ShipmentO__Emplo__5CD6CB2B]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Emplo__5CD6CB2B'
CREATE INDEX [IX_FK__ShipmentO__Emplo__5CD6CB2B]
ON [dbo].[ShipmentOutTemps]
    ([EmployeeId]);
GO

-- Creating foreign key on [MasterBillId] in table 'ShipmentOutTemps'
ALTER TABLE [dbo].[ShipmentOutTemps]
ADD CONSTRAINT [FK__ShipmentO__Maste__5AEE82B9]
    FOREIGN KEY ([MasterBillId])
    REFERENCES [dbo].[MasterBills]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Maste__5AEE82B9'
CREATE INDEX [IX_FK__ShipmentO__Maste__5AEE82B9]
ON [dbo].[ShipmentOutTemps]
    ([MasterBillId]);
GO

-- Creating foreign key on [WarehouseId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__Employee__Wareho__628FA481]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Warehouses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__Wareho__628FA481'
CREATE INDEX [IX_FK__Employee__Wareho__628FA481]
ON [dbo].[Employees]
    ([WarehouseId]);
GO

-- Creating foreign key on [WarehouseId] in table 'ShipmentInfors'
ALTER TABLE [dbo].[ShipmentInfors]
ADD CONSTRAINT [FK__ShipmentI__Wareh__5EBF139D]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Warehouses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__Wareh__5EBF139D'
CREATE INDEX [IX_FK__ShipmentI__Wareh__5EBF139D]
ON [dbo].[ShipmentInfors]
    ([WarehouseId]);
GO

-- Creating foreign key on [WarehouseId] in table 'ShipmentInforTemps'
ALTER TABLE [dbo].[ShipmentInforTemps]
ADD CONSTRAINT [FK__ShipmentI__Wareh__60A75C0F]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Warehouses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentI__Wareh__60A75C0F'
CREATE INDEX [IX_FK__ShipmentI__Wareh__60A75C0F]
ON [dbo].[ShipmentInforTemps]
    ([WarehouseId]);
GO

-- Creating foreign key on [WarehouseId] in table 'ShipmentOuts'
ALTER TABLE [dbo].[ShipmentOuts]
ADD CONSTRAINT [FK__ShipmentO__Wareh__5FB337D6]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Warehouses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Wareh__5FB337D6'
CREATE INDEX [IX_FK__ShipmentO__Wareh__5FB337D6]
ON [dbo].[ShipmentOuts]
    ([WarehouseId]);
GO

-- Creating foreign key on [WarehouseId] in table 'ShipmentOutTemps'
ALTER TABLE [dbo].[ShipmentOutTemps]
ADD CONSTRAINT [FK__ShipmentO__Wareh__619B8048]
    FOREIGN KEY ([WarehouseId])
    REFERENCES [dbo].[Warehouses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ShipmentO__Wareh__619B8048'
CREATE INDEX [IX_FK__ShipmentO__Wareh__619B8048]
ON [dbo].[ShipmentOutTemps]
    ([WarehouseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------