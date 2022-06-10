CREATE OR ALTER PROCEDURE GetProducts 
AS Begin
	SELECT
		productid,
		productname
	FROM
		StoreSample.Production.Products
END 

