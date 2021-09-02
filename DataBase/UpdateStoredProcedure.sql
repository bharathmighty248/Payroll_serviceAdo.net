Create or Alter Procedure spUpdateEmployeeDetails
(
	@Name varchar(20),
	@Salary int
)
As
Begin Try
Update Employee Set Salary=@Salary
Where Name=@Name
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH