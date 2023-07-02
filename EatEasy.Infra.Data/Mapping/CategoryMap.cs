using Microsoft.EntityFrameworkCore;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);
        }
    }
}
