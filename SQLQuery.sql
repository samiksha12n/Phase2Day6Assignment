create database Day6Assignment
use Day6Assignment

create table Products
(PId int primary key,
PName nvarchar(50) not null,
Price float,
Quantity int,
MfgDate date,
ExpDate date)

insert into products values(1,'Shampoo',550.50,800,'10/12/2022','10/12/2024')

select * from Products
---------------------------------------------
create proc usp_iProducts
@id int,
@name nvarchar(50),
@price float,
@qty int,
@mfgdate date,
@expdate date
as
insert into Products(PId,PName,Price,Quantity,MfgDate,ExpDate) values(@id,@name,@price,@qty,@mfgdate,@expdate)

exec usp_iProducts 2,'Detergent',750.90,465,'09/01/2022','09/01/2023'
---------------------------------------------------------------
create proc usp_dProducts
@id int
as
delete from Products where PId=@id

exec usp_dProducts 2
----------------------------------------------------------------
create proc usp_uProducts
@id int,
@name nvarchar(50),
@price float,
@qty int,
@mfgdate date,
@expdate date
as
update Products set PName=@name,Price=@price,Quantity=@qty,MfgDate=@mfgdate,ExpDate=@expdate where PId=@id

------------------------------------------------------------------------
create proc usp_sProducts
@id int
as
select * from Products where PId=@id

