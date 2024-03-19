using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class UserAddressEntityTypeConfig : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.ToTable(nameof(UserAddress));
            builder.HasKey(u => u.Id);
            builder.Property(u => u).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(u => u.StreetName).IsRequired();
            builder.Property(u => u.BuildingNumber).IsRequired();
            builder.Property(u => u.ZipCode).IsRequired();
            builder.Property(u => u.City).IsRequired();

            builder.HasOne(a => a.UserNavigation)
                .WithMany(u => u.UserAddressesNavigation)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}