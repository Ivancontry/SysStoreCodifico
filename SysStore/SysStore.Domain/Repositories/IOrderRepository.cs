using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Sales.Orders;
using System;
using System.Collections.Generic;

namespace SysStore.Domain.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public List<SalesDatePredictioDTO> GetSalesDatePrediction(string customerName);

    }

    public class SalesDatePredictioDTO { 
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
