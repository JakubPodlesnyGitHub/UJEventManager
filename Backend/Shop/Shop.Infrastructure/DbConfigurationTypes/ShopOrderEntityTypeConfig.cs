using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfigurationTypes
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

            builder.HasOne(s => s.PaymentNavigation)
                .WithMany(p => p.ShopOrdersNavigation)
                .HasForeignKey(p => p.IdPayment)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.UserNavigation)
                .WithMany(u => u.ShopOrdersNavigation)
                .HasForeignKey(s => s.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.OrderAddressNavigation)
                .WithMany(p => p.ShopOrdersNavigation)
                .HasForeignKey(p => p.IdOrderAddress)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedDataProvider.ShopOrdersSeed);
        }
    }
}