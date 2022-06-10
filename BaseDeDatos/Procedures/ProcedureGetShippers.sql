CREATE OR ALTER PROCEDURE GetShippers
AS Begin
	SELECT
		shipperid,
		companyname
	FROM
		StoreSample.Sales.Shippers;
END 