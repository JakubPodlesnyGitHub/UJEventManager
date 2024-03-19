using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class CategoryEntityTypeConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(p => p.Id);
            builder.Property(p => p).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();

            builder.HasMany(c => c.ProductCategoriesNavigation)
                .WithOne(pc => pc.CategoryNavigation)
                .HasForeignKey(pc => pc.IdCategory)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}