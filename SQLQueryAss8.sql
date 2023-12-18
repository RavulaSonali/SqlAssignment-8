create database Ass8Db
use Ass8Db

drop table Products

create table Products(
ProductId nvarchar(50) primary key,
ProductName nvarchar(50) not null,
ProductPrice int not null,
MnfDate date not null,
ExpDate date not null)

INSERT INTO Products (ProductId, ProductName, ProductPrice, MnfDate, ExpDate)
VALUES 
    ('P0001', 'Chocolate', 20, '2023-01-01', '2023-12-31'),
    ('P0002', 'Cake', 25, '2023-02-15', '2023-11-30'),
    ('P0003', 'Bread', 30, '2023-03-10', '2024-03-09'),
    ('P0004', 'Samosa', 15, '2023-04-05', '2023-10-15'),
    ('P0005', 'Puffs', 22, '2023-05-20', '2024-02-28'),
    ('P0006', 'Mixture', 18, '2023-06-25', '2023-09-30'),
    ('P0007', 'Egg-Puffs', 28, '2023-07-12', '2024-01-15'),
    ('P0008', 'Lollipop', 35, '2023-08-08', '2023-12-01'),
    ('P0009', 'Candies', 40, '2023-09-03', '2024-06-30'),
    ('P0010', 'Pastry', 16, '2023-10-18', '2023-11-20');

	select * from Products
