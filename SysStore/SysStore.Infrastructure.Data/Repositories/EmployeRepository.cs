using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Repositories
{
    public class EmployeRepository : GenericRepository<Employe>, IEmployeRepository
    {
        public EmployeRepository(IDbContext context): base(context)
        {

        }
        
    }
}
