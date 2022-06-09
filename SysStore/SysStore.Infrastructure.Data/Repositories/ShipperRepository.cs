using SysStore.Domain.Entities.Sales.Shippers;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Repositories
{
    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(IDbContext context): base(context)
        {

        }
        
    }
}
