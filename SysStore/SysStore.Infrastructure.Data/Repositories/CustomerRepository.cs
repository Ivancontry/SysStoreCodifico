using SysStore.Domain.Entities.Sales.Customers;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContext context): base(context)
        {

        }
        
    }
}
