using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class ShopOrderEntityTypeConfig : IEntityTypeConfiguration<ShopOrder>
    {
        public void Configure(EntityTypeBuilder<ShopOrder> builder)
        {
            builder.ToTable(nameof(ShopOrder));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.OrderCode).HasMaxLength(12).IsRequired();
            builder.Property(s => s.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);
            builder.Property(s => s.ExpectedLeadTime).IsRequired().HasColumnType("date");
            builder.Property(s => s.Total).IsRequired().HasColumnType("decimal");

            builder.HasMany(o => o.OrderAddressesNavigation)
                .WithOne(o => o.ShopOrderNavigation)
                .HasForeignKey(o => o.IdShopOrder)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}