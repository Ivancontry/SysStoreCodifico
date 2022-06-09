using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Employees;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.ToTable("Employees",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.EmplId);
        }
    }
}
