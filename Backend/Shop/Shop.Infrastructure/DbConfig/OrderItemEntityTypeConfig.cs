using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class OrderItemEntityTypeConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(nameof(OrderItem));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.Price).IsRequired().HasDefaultValue("decimal");
            builder.Property(o => o.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(o => o.ProductNavigation)
                .WithMany(o => o.OrderItemsNavigation)
                .HasForeignKey(o => o.IdProduct)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.ShopOrderNavigation)
                .WithMany(o => o.OrderItemsNavigation)
                .HasForeignKey(o => o.IdOrder)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
