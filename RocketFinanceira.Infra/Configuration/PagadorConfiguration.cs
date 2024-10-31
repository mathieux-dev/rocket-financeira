using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Configuration;

public class PagadorConfiguration : IEntityTypeConfiguration<Pagador>
{
    public void Configure(EntityTypeBuilder<Pagador> builder)
    {
        builder.ToTable("PAGADORES");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
               .HasColumnName("ID")
               .HasDefaultValueSql("gen_random_uuid()")
               .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
               .HasColumnName("NOME")
               .IsRequired();

        builder.Property(p => p.CPF)
               .HasColumnName("CPF")
               .IsRequired();

        builder.Property(p => p.DataNascimento)
               .HasColumnName("DATA_NASCIMENTO")
               .IsRequired();

        builder.HasOne(p => p.Endereco)
               .WithMany() 
               .HasForeignKey("ENDERECO_ID")
               .IsRequired();

        builder.HasOne(p => p.Instituicao)
               .WithMany() 
               .HasForeignKey("INSTITUICAO_ID")
               .IsRequired();

        builder.OwnsOne(p => p.Contato, contato =>
        {
            contato.Property(c => c.Email).HasColumnName("EMAIL_CONTATO").IsRequired();
            contato.Property(c => c.Telefone).HasColumnName("TELEFONE_CONTATO").IsRequired();
        });
    }
}
