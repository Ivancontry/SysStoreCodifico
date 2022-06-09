using System;
using System.Threading.Tasks;
using SysStore.Domain.Base;
using SysStore.Domain.Repositories;
namespace SysStore.Domain.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;
        public ICategoryRepository CategorysRepository { get; }
        public ICustomerRepository ClientsRepository { get; }
        public IOrderRepository InvoicesMasterRepository { get; }
        public IEmployeRepository EmployeesRepository { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
