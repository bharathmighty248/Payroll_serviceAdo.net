create database EmployeePayroll

use EmployeePayroll


Create Table Employee (
EmpId int identity (1,1) primary key,
Name varchar(20),
Gender varchar(1),
Phone varchar(12),
Address varchar(20),
Department varchar(20),
Salary int,
Startdate Datetime,
)

Select * from Employee

Insert into Employee (Name, Gender, Phone, Address, Department, Salary, Startdate) Values ('Bharath', 'M', '1111111111', 'Hyderabad', 'HR', '50000', '2021-05-26')

Insert into Employee (Name, Gender, Phone, Address, Department, Salary, Startdate) Values ('Susmitha', 'F', '2222222222', 'Hyderabad', 'Accounts', '60000', '2021-07-25')