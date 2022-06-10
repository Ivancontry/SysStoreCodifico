SELECT
  Customers.custid as CustId,
  Customers.companyname as CustomerName,
  MAX(Orders.orderdate) as LastOrderDate,
  DATEADD(
    DAY,
    (
      DATEDIFF(day, MIN(Orders.orderdate), MAX(Orders.orderdate)) / COUNT(Orders.orderid)
    ),
    MAX(Orders.orderdate)
  ) as NextPredictedOrder
FROM
  [StoreSample].[Sales].[Customers] as Customers
  inner join Sales.Orders as Orders on Customers.custid = Orders.custid
GROUP BY
  Customers.companyname,
  Customers.custid
HAVING
  COUNT(Orders.orderid) > 1
ORDER BY
  Customers.companyname asc