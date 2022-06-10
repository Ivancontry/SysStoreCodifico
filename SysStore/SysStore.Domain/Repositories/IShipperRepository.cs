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
        List<GetShipperDTO> GetShippers();
    }
    public class GetShipperDTO 
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
    }
}
