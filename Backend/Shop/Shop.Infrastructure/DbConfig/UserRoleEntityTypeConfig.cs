using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class UserRoleEntityTypeConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(u => u.Name).IsRequired();

            builder.HasMany(r => r.Users)
                .WithOne(u => u.RoleNavigation)
                .HasForeignKey(r => r.IdRole)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}