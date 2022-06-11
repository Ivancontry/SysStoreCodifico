using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Categorys;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", StoreDataContext.SchemaProduction);
            builder.HasKey(t => t.Productid);

            builder.HasOne(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
