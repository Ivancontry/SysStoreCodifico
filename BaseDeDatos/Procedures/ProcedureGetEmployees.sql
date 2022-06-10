CREATE OR ALTER PROCEDURE GetEmployees
AS Begin
	SELECT
		empid,
		CONCAT(firstname, lastname)
	FROM
		StoreSample.HR.Employees;
END 
