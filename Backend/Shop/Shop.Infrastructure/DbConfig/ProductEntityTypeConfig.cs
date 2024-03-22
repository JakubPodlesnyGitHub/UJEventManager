using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal class ProductEntityTypeConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.Id);
            builder.Property(p => p).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Category).IsRequired();
            builder.Property(p => p.CodeNumber).IsRequired().HasMaxLength(6);
            builder.Property(p => p.SeriesNumber).IsRequired().HasMaxLength(8);
            builder.Property(p => p.Description).HasMaxLength(5000);
            builder.Property(p => p.ReleaseDate).HasColumnType("date");
            builder.Property(p => p.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);

            builder.HasMany(c => c.ProductCategoriesNavigation)
                .WithOne(pc => pc.ProductNavigation)
                .HasForeignKey(pc => pc.IdProduct)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProductAvailabilitiesNavigation)
                .WithOne(pc => pc.ProductNavigation)
                .HasForeignKey(pc => pc.IdProduct)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}