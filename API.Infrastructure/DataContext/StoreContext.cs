using API.Core.DbModels;
using API.Core.DbModels.Identity;
using API.Core.DbModels.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace API.Infrastructure.DataContext
{
    public class StoreContext: IdentityDbContext<AppUser>
    {
         public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<AppUser> AppUsers{ get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }


        //dotnet ef migrations add initialMigration -s ./API/ --context StoreContext
    }
}
