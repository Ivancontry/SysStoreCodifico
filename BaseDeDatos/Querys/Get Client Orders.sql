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
    custid = 58