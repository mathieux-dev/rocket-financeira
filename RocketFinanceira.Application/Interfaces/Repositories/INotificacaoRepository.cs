using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Domain.Enums;

namespace RocketFinanceira.Application.Interfaces.Repositories;

public interface INotificacaoRepository : IGenericRepository<Notificacao>
{
    Task<IEnumerable<Notificacao>> ObterNotificacoesNaoEnviadasAsync();
    Task EnviarNotificacaoAsync(Guid notificacaoId);
    Task<IEnumerable<Notificacao>> ObterNotificacoesPorTipoAsync(TipoNotificacao tipo);
    Task<IEnumerable<Notificacao>> ObterNotificacoesPorPagadorAsync(Guid pagadorId);
}
