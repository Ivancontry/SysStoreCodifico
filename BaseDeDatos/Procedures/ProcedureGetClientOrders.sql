/* GetClientOrders  */
CREATE OR ALTER PROCEDURE GetClientOrders 
	@customerId int 
AS Begin
	SELECT
		orderid,
		requireddate,
		shippeddate,
		shipname,
		shipaddress,
		shipcity
	FROM
		StoreSample.Sales.Orders
	WHERE
		custid = @customerId
END 

