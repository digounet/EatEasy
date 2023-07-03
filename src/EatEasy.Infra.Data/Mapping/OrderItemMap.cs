using Microsoft.EntityFrameworkCore;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderId)
                .IsRequired()
                .HasColumnName("order_id_fk");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("product_id_fk");

            builder.Property(x => x.Qty)
                .IsRequired()
                .HasColumnName("qty");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("unit_price");

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnName("total");

            builder.HasOne(i => i.Product)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(prop => prop.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(prop => prop.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
