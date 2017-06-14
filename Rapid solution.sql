Create database RapidSolution
go
use RapidSolution
go
Create table [MasterBill]
(
	Id int identity primary key,
	MasterAirWayBill varchar(100) unique,
	DateCreated DateTime default getdate(),
	DateArrived DateTime
)
go
Create table BoxInfo
(
	Id int identity primary key,
	BoxId varchar(100) unique,
	DateCreated DateTime default getdate(),
	ShipmentQuantity int,
	MasterBillId int references MasterBill(Id)
)
go
Create table ShipmentInfor
(
	Id int identity primary key,
	ShipmentId varchar(100) unique,
	DateCreated DateTime default getdate(),
	Sender nvarchar(300),
	Receiver nvarchar(300),
	TelReceiver varchar(50),
	TotalValue float,
	Descrition nvarchar(1000),
	BoxId int references BoxInfo(Id),
	[Status] nvarchar(100)
)
--Alter table ShipmentInfor add [Status] nvarchar(100)
go
Create table ShipmentOut
(
	ShipmentId varchar(100) references ShipmentInfor(ShipmentId) primary key,
	BoxIdRef int references BoxInfo(Id),
	BoxIdString varchar(100),
	MasterBillId int references [MasterBill](Id),
	MasterBillIdString varchar(100),
	DateOut DateTime default getdate()
)
go
Create table ShipmentWaitToConfirm
(
	ShipmentId varchar(100) references ShipmentInfor(ShipmentId) primary key,
	CreatedDate DateTime default getdate()
)
go
CREATE TABLE ErrorLog(
	[Id] [int] IDENTITY(1,1) primary key,
	[CreationDate] [datetime] NULL,
	[AppCode] [nvarchar](4000) NULL,
	[ErrorCode] [nvarchar](4000) NULL,
	[ErrorMessage] [nvarchar](max) NULL
)
GO
CREATE TABLE [dbo].[Manifest](
	[Id] [int] IDENTITY(1,1) primary key,
	[SysDate] [datetime] NULL,
	[Active] [bit] NULL,
	[MasterAirWayBill] [varchar](100) NULL,
	[ShipmentNo] [varchar](100) NULL,
	[FlightNumber] [varchar](50) NULL,
	[FlightDate] [varchar](50) NULL,
	[BoxID] [varchar](100) NULL,
	[HSCode] [varchar](100) NULL,
	[ContactName] [nvarchar](100) NULL,
	[Tel] [varchar](200) NULL,
	[Address] [nvarchar](1000) NULL,
	[Currency] [nvarchar](20) NULL,
	[Content] [nvarchar](1000) NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[TotalValue] [float] NULL,
	[Weight] [float] NULL,
	[Original] [nvarchar](100) NULL,
	[Destination] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[CompanyName] [nvarchar](200) NULL,
	[CreationDate] [datetime] NULL
)
--Alter table ShipmentOut add BoxId int references BoxInfo(Id)
--go
--Alter table ShipmentOut add MasterBillId int references [MasterBill](Id)
--go
--Alter table ShipmentOut add BoxIdString  varchar(100) 
--go
--Alter table ShipmentOut add MasterBillIdString varchar(100)
--go
CREATE proc [dbo].[InsertManifest]
(
@MasterAirWayBill varchar(100),
@ShipmentNo varchar(100),
@FlightNumber varchar(50),
@FlightDate varchar(50),
@BoxID varchar(100),
@HSCode varchar(100),
@ContactName nvarchar(100),
@Tel varchar(200),
@Address nvarchar(1000),
@Currency nvarchar(20),
@Content nvarchar(1000),
@Quantity	int,
@UnitPrice	float,
@TotalValue	float,
@Weight float,
@Original	nvarchar(100),
@Destination nvarchar(100),
@Country nvarchar(100),
@CompanyName nvarchar(200),
@CreationDate datetime,
@ParamReturn int out) 
AS

BEGIN
Insert into Manifest(
MasterAirWayBill,
ShipmentNo,
FlightNumber,
FlightDate,
BoxID,
HSCode,
ContactName,
Tel,
Address,
Currency,
Content,
Quantity,
UnitPrice,
TotalValue,
Weight,
Original,
Destination,
Country,
CompanyName,
CreationDate
) 
VALUES(
@MasterAirWayBill,
@ShipmentNo,
@FlightNumber,
@FlightDate,
@BoxID,
@HSCode,
@ContactName,
@Tel,
@Address,
@Currency,
@Content,
@Quantity,
@UnitPrice,
@TotalValue,
@Weight,
@Original,
@Destination,
@Country,
@CompanyName,
@CreationDate)
SELECT @ParamReturn = @@IDENTITY;
Select @ParamReturn;
END;



GO