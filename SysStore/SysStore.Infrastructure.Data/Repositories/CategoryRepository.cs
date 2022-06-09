using SysStore.Domain.Entities.Categorys;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context): base(context)
        {

        }        
    }
}
