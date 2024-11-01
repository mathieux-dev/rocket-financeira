using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Domain.Enums;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.Infra.Repositories;

public class CobrancaRepository : GenericRepository<Cobranca>, ICobrancaRepository
{
    public CobrancaRepository(RocketFinanceiraDbContext context) : base(context) { }

    public async Task GerarCobrancaParaPagadorAsync(Guid pagadorId, Cobranca cobranca)
    {
        cobranca.Pagador.Id = pagadorId;
        await _context.Cobrancas.AddAsync(cobranca);
    }

    public async Task<IEnumerable<Cobranca>> ObterCobrancasPorStatusAsync(StatusCobranca status)
        => await _context.Cobrancas.Where(c => c.StatusCobranca == status).ToListAsync();

    public async Task AtualizarStatusCobrancaAsync(Guid cobrancaId, StatusCobranca status)
    {
        var cobranca = await _context.Cobrancas.FindAsync(cobrancaId);
        if (cobranca != null) cobranca.StatusCobranca = status;
    }

    public async Task<IEnumerable<Cobranca>> ObterCobrancasPorIntervaloAsync(DateTime inicio, DateTime fim)
        => await _context.Cobrancas
            .Where(c => c.DataCobranca >= inicio && c.DataCobranca <= fim)
            .ToListAsync();
}
