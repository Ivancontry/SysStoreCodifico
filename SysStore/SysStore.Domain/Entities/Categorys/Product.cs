using System;
using SysStore.Domain.Base;
namespace SysStore.Domain.Entities.Categorys
{
    public class Product
    {
        public long Productid { get; set; }
        public string ProductName { get; set; }
        public long SupplierId { get; set; }
        public long CategoryId { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }
        public bool Discontinued { get; set; }

        public Product()
        {

        }
    }
}
