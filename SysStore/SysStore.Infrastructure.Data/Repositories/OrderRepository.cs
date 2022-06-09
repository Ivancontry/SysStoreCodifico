using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace SysStore.Infrastructure.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContext context): base(context)
        {

        }

        public List<SalesDatePredictioDTO> GetSalesDatePrediction(string customerName)
        {
            var context = Db as StoreDataContext;
            string sql = "EXEC GetSalesDatePrediction @customerName";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@customerName", Value = customerName}
            };
            var salesDatePredictionDto = context.SalesDatePredictioDTO.FromSqlRaw(sql,parms.ToArray()).ToList();
            
            return salesDatePredictionDto;
        }

        
    }
}
