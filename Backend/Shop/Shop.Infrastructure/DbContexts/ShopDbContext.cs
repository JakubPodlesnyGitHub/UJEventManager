using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbContexts
{
    public class ShopDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductAvailability> ProductAvailabilities { get; set; }
        public virtual DbSet<ProductCategory> ProductsCategories { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderAddress> OrderAddresses { get; set; }
        public virtual DbSet<ShopOrder> ShopOrders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        }
    }
}
