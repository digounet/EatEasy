using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderDate)
                .IsRequired()
                .HasColumnName("order_date");

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnName("total");

            builder.Property(x => x.Sequence)
                .IsRequired()
                .HasColumnName("sequence");

            builder.Property(c => c.OrderStatus)
                .HasColumnName("order_status")
                .HasMaxLength(15)
                .HasConversion(x => x.ToString(),
                    x => (OrderStatus)Enum.Parse(typeof(OrderStatus), x));

            builder.HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
