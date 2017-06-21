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
GO
INSERT [dbo].[Employee] ([FullName], [UserName], [Pasword], [Role], [DateCreated], [BirthDate], [Phone], [Email], [Address], [Status]) VALUES (N'admin', N'admin', N'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAka8GbBLIgUu0GBdToiS0egQAAAACAAAAAAAQZgAAAAEAACAAAAACe9ndbi3DhCVm41mfyD/xPZ/VIWh2IzXe+Sdf8bCHNAAAAAAOgAAAAAIAACAAAABxUH8KkL7QQn40zlFUpVyzRE2cUU/JwVLLR6SLdV7pvzAAAAA8j1wsZmqPuy5M/jgLID16ly0vGoMRy62GwyEBDRMi08EXWvvKOFC/zIxT0MC7YphAAAAA0Nd5aTtBorr9AX3YNizfOjbJe9JrPsbMq0Wm3SIleGtv+DkWsCo+Xf7JBdoZmeGQTFncfV4jsfpe6W0WzgLxuQ==', N'Administrator', CAST(N'2017-06-21 03:58:22.063' AS DateTime), CAST(N'2017-06-21 03:57:50.273' AS DateTime), N'1234567890', N'dsfdgjdh', N'fdsgfh', NULL)