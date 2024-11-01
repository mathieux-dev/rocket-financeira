using RocketFinanceira.Application.Interfaces;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Infra.Data;
using RocketFinanceira.Infra.Repositories;

namespace RocketFinanceira.Infra;

public class UnitOfWork : IUnitOfWork
{
    private readonly RocketFinanceiraDbContext _context;
    public IGenericRepository<Instituicao> Instituicoes { get; }
    public IGenericRepository<Pagador> Pagadores { get; }
    public IGenericRepository<Cobranca> Cobrancas { get; }
    public IGenericRepository<Notificacao> Notificacoes { get; }
    public IGenericRepository<Endereco> Enderecos { get; }

    public UnitOfWork(RocketFinanceiraDbContext context)
    {
        _context = context;
        Instituicoes = new GenericRepository<Instituicao>(_context);
        Pagadores = new GenericRepository<Pagador>(_context);
        Cobrancas = new GenericRepository<Cobranca>(_context);
        Notificacoes = new GenericRepository<Notificacao>(_context);
        Enderecos = new GenericRepository<Endereco>(_context);
    }

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
