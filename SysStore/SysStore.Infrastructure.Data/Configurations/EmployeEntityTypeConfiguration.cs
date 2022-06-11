using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysStore.Domain.Entities.Employees;

namespace SysStore.Infrastructure.Data.Configurations
{
    public class EmployeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees",StoreDataContext.SchemaHR);
            builder.HasKey(t => t.EmpId);
            builder.Property(t=> t.LastName).HasColumnName("lastname");
            builder.Property(t=> t.FirstName).HasColumnName("firstname");
            builder.Property(t=> t.Title).HasColumnName("title");
            builder.Property(t=> t.TitleOfCourtesy).HasColumnName("titleofcourtesy");
            builder.Property(t=> t.BirthDate).HasColumnName("birthdate");
            builder.Property(t=> t.HireDate).HasColumnName("hiredate");
            builder.Property(t=> t.Address).HasColumnName("address");
            builder.Property(t=> t.City).HasColumnName("city");
            builder.Property(t=> t.Region).HasColumnName("region");
            builder.Property(t=> t.PostalCode).HasColumnName("postalcode");
            builder.Property(t=> t.Country).HasColumnName("country");
            builder.Property(t=> t.Phone).HasColumnName("phone");
            builder.Property(t => t.Mgrid).HasColumnName("mgrid");
        }
    }
}
