using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Configuration;

public class InstituicaoConfiguration : IEntityTypeConfiguration<Instituicao>
{
    public void Configure(EntityTypeBuilder<Instituicao> builder)
    {
        builder.ToTable("INSTITUICOES");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
               .HasColumnName("ID")
               .HasDefaultValueSql("gen_random_uuid()")
               .ValueGeneratedOnAdd();

        builder.Property(i => i.Nome)
               .HasColumnName("NOME")
               .IsRequired();

        builder.Property(i => i.CNPJ)
               .HasColumnName("CNPJ")
               .IsRequired();

        builder.HasOne(i => i.Endereco)
               .WithMany()
               .HasForeignKey("ENDERECO_ID")
               .IsRequired();

        builder.OwnsOne(i => i.Contato, contato =>
        {
            contato.Property(c => c.Email).HasColumnName("EMAIL_CONTATO").IsRequired();
            contato.Property(c => c.Telefone).HasColumnName("TELEFONE_CONTATO").IsRequired();
        });
    }
}
