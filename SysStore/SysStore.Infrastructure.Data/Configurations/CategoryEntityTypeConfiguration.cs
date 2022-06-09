using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Categorys;
namespace SysStore.Infrastructure.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.Categoryid);
        }
    }
}
