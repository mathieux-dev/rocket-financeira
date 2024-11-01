using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Domain.Enums;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.Infra.Repositories;

public class NotificacaoRepository : GenericRepository<Notificacao>, INotificacaoRepository
{
    public NotificacaoRepository(RocketFinanceiraDbContext context) : base(context) { }

    public async Task<IEnumerable<Notificacao>> ObterNotificacoesNaoEnviadasAsync()
        => await _context.Notificacoes.Where(n => !n.Enviado).ToListAsync();

    public async Task EnviarNotificacaoAsync(Guid notificacaoId)
    {
        var notificacao = await _context.Notificacoes.FindAsync(notificacaoId);
        if (notificacao != null) notificacao.Enviado = true;
    }

    public async Task<IEnumerable<Notificacao>> ObterNotificacoesPorTipoAsync(TipoNotificacao tipo)
        => await _context.Notificacoes.Where(n => n.Tipo == tipo).ToListAsync();

    public async Task<IEnumerable<Notificacao>> ObterNotificacoesPorPagadorAsync(Guid pagadorId)
        => await _context.Notificacoes.Where(n => n.PagadorId == pagadorId).ToListAsync();
}
