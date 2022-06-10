CREATE OR ALTER PROCEDURE AddNewOrder 
	@custid int,
	@empid int,
	@shipperid int,
	@shipName nvarchar(40),
	@shipAddress nvarchar(60),
	@shipCity nvarchar(15),
	@orderDate datetime,
	@requiredDate datetime,
	@shippedDate datetime,
	@freigth money,
	@shipCountry nvarchar(15),
	@unitPrice money,
	@qty smallint,
	@discount numeric,
	@productId int 
AS BEGIN 
	DECLARE @OrderID int;
	INSERT INTO
		StoreSample.Sales.Orders(
			custid,
			empid,
			shipperid,
			shipname,
			shipaddress,
			shipcity,
			orderdate,
			requireddate,
			shippeddate,
			freight,
			shipcountry
		)
	VALUES
		(
			@custid,
			@empid,
			@shipperid,
			@shipName,
			@shipAddress,
			@shipCity,
			@orderDate,
			@requiredDate,
			@shippedDate,
			@freigth,
			@shipCountry
		)
	SET	@OrderID = SCOPE_IDENTITY()
	INSERT INTO
		StoreSample.Sales.OrderDetails(orderid, productid, unitprice, qty, discount)
	VALUES
		(
			@OrderID,
			@productId,
			@unitPrice,
			@qty,
			@discount
		)
	SELECT * FROM StoreSample.Sales.Orders WHERE OrderID = @OrderID
END