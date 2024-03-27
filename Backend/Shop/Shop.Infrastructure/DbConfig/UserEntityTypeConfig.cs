using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class UserEntityTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.BirthDate).IsRequired().HasColumnType("date");
            builder.Property(a => a.Email).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();
            builder.Property(u => u.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);

            builder.HasMany(u => u.PaymentsNavigation)
                .WithOne(u => u.UserNavigation)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.ShopOrdersNavigation)
                .WithOne(u => u.UserNavigation)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.UserAddressesNavigation)
                .WithOne(u => u.UserNavigation)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}