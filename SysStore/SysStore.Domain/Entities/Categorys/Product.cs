using System;
using SysStore.Domain.Base;
namespace SysStore.Domain.Entities.Categorys
{
    public class Product
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }
        public bool Discontinued { get; set; }

        public Product()
        {

        }
    }
}
