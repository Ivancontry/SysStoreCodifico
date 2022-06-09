using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContext context): base(context)
        {

        }
        
    }
}
