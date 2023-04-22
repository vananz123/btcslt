use master;
go
create database qlcafe;
go

use qlcafe;
go

create table TableCoffee
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Chưa đặt tên',
	Status nvarchar(100) not null default N'Trống'
)

go

create table Account
(
	UserName varchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Name',
	Password varchar(500) not null default '',
	Role nvarchar(50) not null 
)
go

create table CategoryFood
(
	ID int identity not null primary key,
	Name nvarchar(100) not null default N'Chưa đặt tên'
)
go

create table Food
(
	ID int identity primary key,
	Name nvarchar(100) not null default N'Chưa đặt tên',
	Size nvarchar(10) null default N'',
	Price int not null,
	CategoryID int not null

	foreign key (CategoryID) references CategoryFood(id)
)
go

create table Bill
(
	ID int identity primary key,
	AtCreate Date not null default GETDATE(),
	TableID int not null,
	Discount int not null default 0,
	TotalPrice int default 0,
	Status int not null default 0 -- 1: Da thanh toan, 0: Chua thanh toan

	foreign key (TableID) references TableCoffee(ID)
)
go

create table BillInfo
(
	ID int identity primary key,
	BillID int not null,
	FoodID int not null,
	Amount int not null default 0

	foreign key (BillID) references Bill(ID),
	foreign key (FoodID) references Food(ID)
)
go

declare @i int = 1
while @i <= 30
begin
	insert into TableCoffee(Name)
	values (N'Bàn ' + CAST(@i as nvarchar(100)))
	set @i = @i + 1
end
go

insert into Account (UserName, DisplayName, Password, Role)
values ('admin', 'Quản lý', 'admin', 'Quản lý')
go

insert into Account(UserName, DisplayName, Password, Role)
values ('nhanh', 'Nhân viên (Tài Nhanh)' ,'12345', 'Nhân viên')
go

insert into Account(UserName, DisplayName, Password, Role)
values ('anh', 'Nhân viên (Trúc Anh)' ,'12345', 'Nhân viên')
go
-- add information into Category
insert into CategoryFood (Name) values (N'Cà phê')
insert into CategoryFood (Name) values (N'Ăn vặt')
insert into CategoryFood (Name) values (N'Thức uống khác')
insert into CategoryFood (Name) values (N'Nước ép trái cây')
insert into CategoryFood (Name) values (N'Trà sữa')
go

-- add information into Food
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê đá',N'S',20000, 1)
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê đá',N'M',25000, 1)
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê đá',N'L',30000, 1)
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê sữa',N'S',25000, 1)
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê sữa',N'M',30000, 1)
insert into Food (Name,Size,Price, CategoryID) values (N'Cà phê sữa',N'L',35000, 1)
insert into Food (Name,Price, CategoryID) values (N'Mì cay',45000, 2)
insert into Food (Name,Price, CategoryID) values (N'Sushi',45000, 2)
insert into Food (Name,Price, CategoryID) values (N'Bò viên chiên',30000, 2)
insert into Food (Name,Price, CategoryID) values (N'Xúc xích chiên', 25000,2)
insert into Food (Name,Price, CategoryID) values (N'Ốc nhồi chiên',35000, 2)
insert into Food (Name,Price, CategoryID) values (N'Há cảo chiên', 35000,2)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố cam',N'S',35000, 4)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố cam',N'M',40000 ,4)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố cam',N'L',45000 ,4)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố dâu',N'S',35000, 4)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố dâu',N'M',40000, 4)
insert into Food (Name,Size,Price, CategoryID) values (N'Sinh tố dâu',N'L',45000, 4)
insert into Food (Name,Price, CategoryID) values (N'Trà sữa truyền thống',35000, 5)
insert into Food (Name,Price, CategoryID) values (N'Trà sữa Chocolate',35000, 5)
insert into Food (Name,Price, CategoryID) values (N'Trà sữa Matcha',40000, 5)
insert into Food (Name,Price, CategoryID) values (N'Trà sữa Việt quất',45000, 5)
insert into Food (Name,Price, CategoryID) values (N'Capuchino', 45000,5)
insert into Food (Name,Price, CategoryID) values (N'Macchiato', 40000,5)
go
