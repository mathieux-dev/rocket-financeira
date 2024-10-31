using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("ENDERECOS");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("uuid_generate_v4()");

        builder.Property(e => e.Logradouro)
               .HasColumnName("LOGRADOURO")
               .IsRequired();

        builder.Property(e => e.Numero)
               .HasColumnName("NUMERO")
               .IsRequired();

        builder.Property(e => e.Complemento)
               .HasColumnName("COMPLEMENTO");

        builder.Property(e => e.Bairro)
               .HasColumnName("BAIRRO")
               .IsRequired();

        builder.Property(e => e.Cidade)
               .HasColumnName("CIDADE")
               .IsRequired();

        builder.Property(e => e.Estado)
               .HasColumnName("ESTADO")
               .IsRequired();

        builder.Property(e => e.CEP)
               .HasColumnName("CEP")
               .IsRequired();
    }
}
