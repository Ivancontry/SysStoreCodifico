using System;
using System.Collections.Generic;
using SysStore.Domain.Base;
using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Entities.Sales.Customers;

namespace SysStore.Domain.Entities.Sales.Orders
{
    public class Order : Entity<long>
    {
        public int OrderId { get; set; }
        public int CustId { get; set; }
        public Customer Client { get; set; }
        public int EmpId { get; set; }
        public Employe Employe { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string Shipname { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        private Order()
        {

        }
        

    }
}
