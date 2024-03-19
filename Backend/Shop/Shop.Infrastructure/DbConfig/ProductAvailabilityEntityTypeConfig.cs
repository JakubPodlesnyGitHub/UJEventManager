using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class ProductAvailabilityEntityTypeConfig : IEntityTypeConfiguration<ProductAvailability>
    {
        public void Configure(EntityTypeBuilder<ProductAvailability> builder)
        {
            builder.ToTable(nameof(ProductAvailability));
            builder.HasKey(p => p.Id);
            builder.Property(p => p).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Availability).IsRequired();
            builder.Property(p => p.SnapshotStatusTime).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);
        }
    }
}