using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysStore.Domain.Repositories
{
    public interface IEmployeRepository : IGenericRepository<Employee>
    {
        List<GetEmployeeDTO> GetEmployees();
    }
    public class GetEmployeeDTO
    {
        public int EmpId{get;set;}
        public string FullName { get; set; }
    }
}
