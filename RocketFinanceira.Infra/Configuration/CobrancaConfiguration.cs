using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Configuration;

public class CobrancaConfiguration : IEntityTypeConfiguration<Cobranca>
{
    public void Configure(EntityTypeBuilder<Cobranca> builder)
    {
        builder.ToTable("COBRANCAS");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
               .HasColumnName("ID")
               .HasDefaultValueSql("gen_random_uuid()")
               .ValueGeneratedOnAdd();

        builder.Property(c => c.TipoCobranca)
               .HasColumnName("TIPO_COBRANCA")
               .HasConversion<string>()
               .IsRequired();

        builder.Property(c => c.TipoPagamento)
               .HasColumnName("TIPO_PAGAMENTO")
               .HasConversion<string>()
               .IsRequired();

        builder.Property(c => c.StatusCobranca)
               .HasColumnName("STATUS_COBRANCA")
               .HasConversion<string>()
               .IsRequired();

        builder.Property(c => c.Recorrente)
               .HasColumnName("RECORRENTE")
               .IsRequired();

        builder.Property(c => c.IntervaloRecorrencia)
               .HasColumnName("INTERVALO_RECORRENCIA")
               .HasConversion<string>();

        builder.Property(c => c.DataCobranca)
               .HasColumnName("DATA_COBRANCA")
               .IsRequired();

        builder.Property(c => c.Valor)
               .HasColumnName("VALOR")
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.HasOne(c => c.Pagador)
               .WithMany(p => p.Cobrancas)
               .HasForeignKey("PAGADOR_ID")
               .IsRequired();
    }
}
