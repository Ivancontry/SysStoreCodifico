using System;
using System.Threading.Tasks;
using SysStore.Domain.Base;
using SysStore.Domain.Contracts;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Repositories;
namespace SysStore.Infrastructure.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private ICategoryRepository _categorysRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IEmployeRepository _employeRepository;
        private IShipperRepository _shipperRepository;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }

        public IOrderRepository OrdersRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_dbContext);
            }
        }
        public ICategoryRepository CategorysRepository
        {
            get
            {
                return _categorysRepository ??= new CategoryRepository(_dbContext);
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new CustomerRepository(_dbContext);
            }
        }

        public IEmployeRepository EmployeesRepository
        {
            get
            {
                return _employeRepository ??= new EmployeRepository(_dbContext);
            }
        }
        public IShipperRepository ShippersRepository
        {
            get
            {
                return _shipperRepository ??= new ShipperRepository(_dbContext);
            }
        }

        public Task<int> CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            _dbContext.DoDispose();
            _dbContext = null;
        }
    }
}
