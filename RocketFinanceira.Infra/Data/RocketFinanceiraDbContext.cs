using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Infra.Data;

public class RocketFinanceiraDbContext(DbContextOptions<RocketFinanceiraDbContext> options) : DbContext(options)
{
    public DbSet<Instituicao> Instituicoes { get; set; }
    public DbSet<Pagador> Pagadores { get; set; }
    public DbSet<Cobranca> Cobrancas { get; set; }
    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RocketFinanceiraDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
