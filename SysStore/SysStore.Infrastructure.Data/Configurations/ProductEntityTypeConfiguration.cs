using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Infrastructure.Data.Base;
namespace SysStore.Infrastructure.Data.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Categorys.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Categorys.Product> builder)
        {
            builder.ToTable("Products", StoreDataContext.SchemaSales);
            builder.HasKey(t => t.Productid);

            builder.HasOne(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
