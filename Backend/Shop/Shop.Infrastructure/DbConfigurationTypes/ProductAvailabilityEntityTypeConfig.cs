using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfigurationTypes
{
    internal sealed class ProductAvailabilityEntityTypeConfig : IEntityTypeConfiguration<ProductAvailability>
    {
        public void Configure(EntityTypeBuilder<ProductAvailability> builder)
        {
            builder.ToTable(nameof(ProductAvailability));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Availability).IsRequired();
            builder.Property(p => p.SnapshotStatusTime).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(p => p.ProductNavigation)
                .WithMany(p => p.ProductAvailabilitiesNavigation)
                .HasForeignKey(p => p.IdProduct)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedDataProvider.ProductAvailabilitesSeed);
        }
    }
}