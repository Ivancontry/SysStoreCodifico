using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Employees;
using SysStore.Domain.Entities.Sales.Shippers;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class ShipperEntityTypeConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.ShipperId);
        }

        
    }
}
