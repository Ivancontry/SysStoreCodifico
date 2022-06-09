using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Sales.Orders;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.OrderId);
        }
    }
}
