using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace SysStore.Infrastructure.Data.Repositories
{
    public class EmployeRepository : GenericRepository<Employee>, IEmployeRepository
    {
        public EmployeRepository(IDbContext context): base(context)
        {

        }

        public List<GetEmployeeDTO> GetEmployees()
        {
            var context = Db as StoreDataContext;
            string sql = "EXEC GetEmployees";
            var getEmployeesDTO = context.GetEmployeesDTO.FromSqlRaw(sql).ToList();
            return getEmployeesDTO;
        }
    }
}
