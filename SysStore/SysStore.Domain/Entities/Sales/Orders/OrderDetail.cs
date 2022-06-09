using SysStore.Domain.Base;
using SysStore.Domain.Entities.Categorys;
namespace SysStore.Domain.Entities.Sales.Orders
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }

        public OrderDetail()
        {

        }      
    }
}
