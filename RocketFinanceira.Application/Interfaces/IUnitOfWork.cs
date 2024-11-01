using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Instituicao> Instituicoes { get; }
    IGenericRepository<Pagador> Pagadores { get; }
    IGenericRepository<Cobranca> Cobrancas { get; }
    IGenericRepository<Notificacao> Notificacoes { get; }
    IGenericRepository<Endereco> Enderecos { get; }
    Task<int> CommitAsync();
}
