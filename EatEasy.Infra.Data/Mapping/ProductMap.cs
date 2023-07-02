using Microsoft.EntityFrameworkCore;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("varchar(400)")
                .HasMaxLength(400);

            builder.Property(x => x.CategoryID)
                .IsRequired()
                .HasColumnName("category_id_fk");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("price");

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
