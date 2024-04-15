using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfigurationTypes
{
    internal sealed class ProductCategoryEntityTypeConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory));
            builder.HasKey(pc => new { pc.IdProduct, pc.IdCategory });

            builder.Property(pc => pc.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(pc => pc.ProductNavigation)
                .WithMany(p => p.ProductCategoriesNavigation)
                .HasForeignKey(pc => pc.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(pc => pc.CategoryNavigation)
                .WithMany(c => c.ProductCategoriesNavigation)
                .HasForeignKey(pc => pc.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Navigation(b => b.ProductNavigation).AutoInclude();
            builder.Navigation(b => b.CategoryNavigation).AutoInclude();

            builder.HasData(SeedDataProvider.ProductsCategoriesSeed);
        }
    }
}