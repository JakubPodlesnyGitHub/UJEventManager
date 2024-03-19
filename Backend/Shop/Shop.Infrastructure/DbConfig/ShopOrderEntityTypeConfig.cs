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
            builder.Property(s => s.Id).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
}