using Microsoft.EntityFrameworkCore;
using EatEasy.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatEasy.Infra.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

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

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(x => x.MobilePhone)
                .IsRequired()
                .HasColumnName("pobile_phone")
                .HasColumnType("varchar(15)")
                .HasMaxLength(15);
        }
    }
}
