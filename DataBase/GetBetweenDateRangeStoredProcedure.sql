Create or Alter procedure spGetAllEmployeeBetweenDateRange
(
	@Date1 datetime,
	@Date2 datetime
)
As 
Begin try
Select * from Employee 
Where StartDate between (@Date1) And (@Date2)
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH