using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Categorys;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace SysStore.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context): base(context)
        {

        }

        public Product GetProduct(int productId)
        {
            var context = Db as StoreDataContext;
            var product = context.Products.Include(p => p.Category)
                                          .FirstOrDefault(t => t.Productid == productId);
            return product;
        }

        public List<GetProductDTO> GetProducts()
        {
            var context = Db as StoreDataContext;
            const string sql = "EXEC GetProducts";           
            var getProductsDTO = context.GetProductsDTO.FromSqlRaw(sql).ToList();
            return getProductsDTO;
        }
    }
}
