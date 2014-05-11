using DevStore.Tdc.Data.Mapping;
using DevStore.Tdc.Domain;
using System.Data.Entity;

namespace DevStore.Tdc.Data
{
    public partial class DevStoreContext : DbContext
    {
        static DevStoreContext()
        {
            Database.SetInitializer<DevStoreContext>(null);
        }

        public DevStoreContext()
            : base("Name=DevStoreContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
