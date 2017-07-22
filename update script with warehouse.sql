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
Alter table [Warehouse] add [Description] nvarchar(500)
go
Insert into Warehouse values('HNW',N'Kho hàng Hà Nội',N'Lô 6 kho hàng sân bay Nội Bài','')
go
Insert into Warehouse values('SGW',N'Kho hàng Hồ Chí Minh',N'Lô 6 kho hàng sân bay Tân Sơn Nhất','')