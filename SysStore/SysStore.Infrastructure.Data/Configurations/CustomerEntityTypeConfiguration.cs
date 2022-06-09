using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Entities.Sales.Customers;
using SysStore.Domain.Entities.Sales.Shippers;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.CustId);
        }

        
    }
}
