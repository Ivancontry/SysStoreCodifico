using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Configurations
{
    public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", StoreDataContext.SchemaSales);
            builder.HasKey(t => t.OrderId);
            builder.HasKey(t => t.ProductId);

            builder.HasOne(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
