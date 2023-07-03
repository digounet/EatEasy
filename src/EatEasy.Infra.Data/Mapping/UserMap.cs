using Microsoft.EntityFrameworkCore;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)")
                .HasMaxLength(11);

            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.CPF).IsUnique();
        }
    }
}
