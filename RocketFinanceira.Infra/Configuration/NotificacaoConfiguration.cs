using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Configuration;

public class NotificacaoConfiguration : IEntityTypeConfiguration<Notificacao>
{
    public void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        builder.ToTable("NOTIFICACOES");

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id)
               .HasColumnName("ID")
               .HasDefaultValueSql("gen_random_uuid()")
               .ValueGeneratedOnAdd();

        builder.Property(n => n.Tipo)
               .HasColumnName("TIPO")
               .HasConversion<string>()
               .IsRequired();

        builder.Property(n => n.DataEnvio)
               .HasColumnName("DATA_ENVIO")
               .IsRequired();

        builder.Property(n => n.Mensagem)
               .HasColumnName("MENSAGEM")
               .IsRequired();

        builder.Property(n => n.Enviado)
               .HasColumnName("ENVIADO")
               .IsRequired();
    }
}
