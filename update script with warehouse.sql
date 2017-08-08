go
Create table Warehouse
(
	Id int identity primary key,
	IdCode varchar(50),
	Name nvarchar(200),
	Location nvarchar(500),
	[Description] nvarchar(500),
	DateCreated datetime default getdate()
)
go
Alter table [ShipmentInfor] add WarehouseId int references Warehouse(Id)
go
Alter table [ShipmentOut] add WarehouseId int references Warehouse(Id)
go
Alter table [ShipmentInforTemp] add WarehouseId int references Warehouse(Id)
go
Alter table [ShipmentOutTemp] add WarehouseId int references Warehouse(Id)
go
Alter table [Employee] add WarehouseId int references Warehouse(Id)
go
Alter table [ShipmentInfor] add IsSyncOms bit
go
Alter table [ShipmentOut] add IsSyncOms bit
go
Insert into Warehouse values('HNW',N'Kho hàng Hà Nội',N'Lô 6 kho hàng sân bay Nội Bài','', getdate())
go
Insert into Warehouse values('SGW',N'Kho hàng Hồ Chí Minh',N'Lô 6 kho hàng sân bay Tân Sơn Nhất','', getdate())
go
update [ShipmentInfor] set IsSyncOms = 0
go
update [ShipmentOut] set IsSyncOms = 0
go
update [ShipmentInfor] set WarehouseId = 1
go
update [ShipmentOut] set WarehouseId = 1

go
--V1.1.2
Alter table [ShipmentInfor] add [Weight] float
go
Alter table [ShipmentInfor] add DeclarationNo varchar(15)
Alter table [ShipmentInfor] add Country nvarchar(100)--o	Nước gửi(Country)
Alter table [ShipmentInfor] add [Address] nvarchar(500)--o	Địa chỉ nhận(Address)
Alter table [ShipmentInfor] add Consignee nvarchar(200)--o	Consignee (Destination).
Alter table [ShipmentInfor] add Content nvarchar(300)--o	Nội dung hàng(Content); 
Alter table [ShipmentInfor] add NumberPackage int default 1--o	Số kiện(mặc định là 1); 
Alter table [ShipmentInfor] add DateOfCompletion DateTime
alter table [dbo].[Manifest] add DeclarationNo varchar(15)