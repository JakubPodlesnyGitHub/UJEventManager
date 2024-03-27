using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Shop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class OrderAddressEntityTypeConfig : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.ToTable(nameof(OrderAddress));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.StreetName).IsRequired();
            builder.Property(o => o.BuildingNumber).IsRequired();
            builder.Property(o => o.ZipCode).IsRequired();
            builder.Property(o => o.City).IsRequired();
            builder.Property(o => o.District).IsRequired();

            builder.HasMany(o => o.ShopOrdersNavigation)
                .WithOne(o => o.OrderAddressNavigation)
                .HasForeignKey(o => o.IdOrderAddress)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
