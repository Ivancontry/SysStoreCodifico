using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Sales.Orders;
using System;
using System.Collections.Generic;

namespace SysStore.Domain.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public List<SaleDatePredictioDTO> GetSalesDatePrediction(string customerName);
        List<OrderForCustomerDTO> GetOrdersForCustomerId(int customerId);
        int AddOrderAndDetail(Order order);
    }

    public class OrderForCustomerDTO
    {
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
    }

    public class SaleDatePredictioDTO { 
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
