CREATE OR ALTER PROCEDURE GetEmployees
AS Begin
	SELECT
		empid,
		CONCAT(firstname,' ', lastname) fullName
	FROM
		StoreSample.HR.Employees;
END 
