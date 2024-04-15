using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfigurationTypes
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

            builder.HasData(SeedDataProvider.OrderAddressesSeed);
        }
    }
}