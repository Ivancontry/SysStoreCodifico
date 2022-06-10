using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Sales.Shippers;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace SysStore.Infrastructure.Data.Repositories
{
    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(IDbContext context): base(context)
        {

        }

        public List<GetShipperDTO> GetShippers()
        {
            var context = Db as StoreDataContext;
            var sql = "EXEC GetShippers";
            var getShippersDTO = context.GetShippersDTO.FromSqlRaw(sql).ToList();
            return getShippersDTO;
        }
    }
}
