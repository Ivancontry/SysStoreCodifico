CREATE PROCEDURE GetSalesDatePrediction
@customerName nvarchar(40)
 AS
 Begin
  SELECT Customers.custid as CustId,Customers.companyname as CustomerName,MAX(Orders.orderdate) as LastOrderDate,
	DATEADD(DAY,(DATEDIFF(day,MIN(Orders.orderdate),MAX(Orders.orderdate))/COUNT(Orders.orderid)),MAX(Orders.orderdate)) as NextPredictedOrder
  FROM [StoreSample].[Sales].[Customers] as Customers 
  right join Sales.Orders as Orders on Customers.custid = Orders.custid 
  group by Customers.companyname,Customers.custid having COUNT(Orders.orderid) > 1 and Customers.companyname like '%'+@customerName+'%'  ORDER BY Customers.companyname asc
END

CREATE PROCEDURE GetClientOrders
	@customerId int
 AS
 Begin
  SELECT orderid,requireddate,shippeddate,shipname,shipaddress,shipcity FROM StoreSample.Sales.Orders WHERE custid = @customerId
END

CREATE PROCEDURE GetEmployees
 AS
 Begin
  SELECT empid, CONCAT(firstname,lastname) FROM StoreSample.HR.Employees;
END

CREATE PROCEDURE GetShippers
 AS
 Begin
  SELECT shipperid,companyname FROM StoreSample.Sales.Shippers;
END

CREATE PROCEDURE GetProducts
 AS
 Begin
  SELECT productid,productname FROM StoreSample.Production.Products;
END

CREATE PROCEDURE AddNewOrder
	   @empid int, @shipperid int, @shipName	nvarchar(40), @shipAddress nvarchar(60),  @shipCity nvarchar(15),
	   @orderDate datetime, @requiredDate datetime, @shippedDate datetime, @freigth money, @shipCountry nvarchar(15),
	   @unitPrice decimal, @qty int, @discount int 
AS
BEGIN
	DECLARE @OrderID int;
	INSERT INTO StoreSample.Sales.Orders(
	   empid,shipperid,shipname,shipaddress,shipcity,orderdate,requireddate,shippeddate,freight,shipcountry
	   )
    VALUES (
		@empid, @shipperid, @shipName, @shipAddress , @shipCity, @orderDate, @requiredDate, @shippedDate,
		@freigth, @shipCountry)
 
	SET @OrderID = SCOPE_IDENTITY()

	INSERT INTO StoreSample.Sales.OrderDetails(
		orderid,unitprice,qty,discount
	)
	VALUES (@OrderID,@unitPrice,@qty,@discount)
END



