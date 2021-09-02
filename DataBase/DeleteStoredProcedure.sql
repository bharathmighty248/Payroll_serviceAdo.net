Create or Alter Procedure spDeleteEmployeeDetails
(
	@EmpId int
)
As
Begin Try
Delete From Employee
Where EmpId=@EmpId
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH