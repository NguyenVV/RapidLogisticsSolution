Create table Employee
(
	Id int identity primary key,
	FullName nvarchar (150),
	UserName nvarchar(150) unique,
	Pasword nvarchar(500),
	[Role] nvarchar(100),
	DateCreated DateTime default getdate(),
	BirthDate DateTime,
	Phone varchar(30),
	Email varchar(150),
	[Address] nvarchar(200),
	[Status] bit
)
go
Alter table [MasterBill] add EmployeeId int references Employee(Id)
go
Alter table BoxInfo add EmployeeId int references Employee(Id)
go
Alter table ShipmentInfor add EmployeeId int references Employee(Id)
go
Alter table ShipmentOut add EmployeeId int references Employee(Id)
go
Alter table ShipmentWaitToConfirm add EmployeeId int references Employee(Id)
go
