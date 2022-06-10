using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace SysStore.Infrastructure.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContext context): base(context)
        {

        }
        public int AddOrderAndDetail(Order order)
        {
            var context = Db as StoreDataContext;
            var orderDetail = order.OrderDetails.FirstOrDefault();            

            var parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@custid", Value = order.CustId},
                new SqlParameter { ParameterName = "@empid", Value = order.EmpId},
                new SqlParameter { ParameterName = "@shipperid", Value = order.ShipperId},
                new SqlParameter { ParameterName = "@shipName", Value = order.Shipname},
                new SqlParameter { ParameterName = "@shipAddress", Value = order.ShipAddress},
                new SqlParameter { ParameterName = "@shipCity", Value = order.ShipCity},
                new SqlParameter { ParameterName = "@orderDate", Value = order.OrderDate},
                new SqlParameter { ParameterName = "@requiredDate", Value = order.RequiredDate},
                new SqlParameter { ParameterName = "@shippedDate", Value = order.ShippedDate},
                new SqlParameter { ParameterName = "@freigth", Value = order.Freight},
                new SqlParameter { ParameterName = "@shipCountry", Value = order.ShipCountry},
                new SqlParameter { ParameterName = "@unitPrice", Value = orderDetail.UnitPrice},
                new SqlParameter { ParameterName = "@qty", Value = orderDetail.Qty},
                new SqlParameter { ParameterName = "@discount", Value =  orderDetail.Discount},
                new SqlParameter { ParameterName = "@productId", Value = orderDetail.ProductId}
            };

            var sql = $"EXEC AddNewOrder {string.Join(", ", parms.Select(t => $"{t.ParameterName}"))}";
            var orderResponse = context.Orders.FromSqlRaw(sql, parms.ToArray()).AsEnumerable().FirstOrDefault();
            return orderResponse.OrderId;
        }

        public List<OrderForCustomerDTO> GetOrdersForCustomerId(int customerId)
        {
            var context = Db as StoreDataContext;
            var sql = "EXEC GetClientOrders @customerId";
            var parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@customerId", Value = customerId}
            };
            var ordersForCustomerDTO = context.OrdersForCustomerDTO.FromSqlRaw(sql, parms.ToArray()).ToList();
            return ordersForCustomerDTO;
        }

        public List<SaleDatePredictioDTO> GetSalesDatePrediction(string customerName)
        {
            var context = Db as StoreDataContext;
            var sql = "EXEC GetSalesDatePrediction @customerName";
            var parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@customerName", Value = customerName}
            };
            var salesDatePredictionDto = context.SalesDatePredictioDTO.FromSqlRaw(sql,parms.ToArray()).ToList();
            
            return salesDatePredictionDto;
        }

        
    }
}
