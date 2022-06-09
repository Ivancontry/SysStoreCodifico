using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Entities.Sales.Shippers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysStore.Domain.Repositories
{
    public interface IShipperRepository : IGenericRepository<Shipper>
    {
        
    }
}
