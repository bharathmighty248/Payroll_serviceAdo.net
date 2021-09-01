Create or Alter Procedure spAddEmployeeDetails
(
	@Name varchar(20),
	@Gender varchar(1),
	@Phone varchar(12),
	@Company varchar(20),
	@Department varchar(20),
	@Salary int,
	@Startdate Datetime
)
As
Begin Try
Insert into Employee(Name, Gender, Phone, Address, Department, Salary, Startdate) Values (@Name, @Gender, @Phone, @Address, @Department, @Salary, @Startdate)
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH
