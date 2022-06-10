using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Employees;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees",StoreDataContext.SchemaSales);
            builder.HasKey(t => t.EmplId);
        }
    }
}
