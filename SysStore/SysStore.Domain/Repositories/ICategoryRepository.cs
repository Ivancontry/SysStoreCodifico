using System;
using System.Collections.Generic;
using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Categorys;
namespace SysStore.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Product GetProduct(int productId);
    }
}
