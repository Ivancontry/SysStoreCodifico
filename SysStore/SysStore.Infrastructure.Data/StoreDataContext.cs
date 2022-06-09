using Microsoft.EntityFrameworkCore;
using SysStore.Domain.Entities.Categorys;
using SysStore.Domain.Entities.Sales.Customers;
using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Domain.Repositories;
using SysStore.Infrastructure.Data.Base;
using SysStore.Infrastructure.Data.Configurations;
namespace SysStore.Infrastructure.Data
{
    public class StoreDataContext: DbContextBase
    {
        public StoreDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SalesDatePredictioDTO> SalesDatePredictioDTO { get; set; }
        public static string SchemaHR => "HR";
        public static string SchemaSales => "Sales";
        public static string SchemaProduction => "Production";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesDatePredictioDTO>().HasNoKey();
            modelBuilder.ApplyConfiguration(new EmployeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShipperEntityTypeConfiguration());
        }
    }
}
