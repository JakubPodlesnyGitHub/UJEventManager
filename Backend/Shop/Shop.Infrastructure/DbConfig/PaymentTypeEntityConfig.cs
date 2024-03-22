using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DbConfig
{
    internal sealed class PaymentTypeEntityConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.PaymentMethod).IsRequired();
            builder.Property(s => s.Data).IsRequired();
            builder.Property(s => s.CreationDate).IsRequired().HasColumnType("date").HasDefaultValue(DateTime.UtcNow);
            builder.Property(s => s.Amount).IsRequired().HasColumnType("decimal");
        }
    }
}
