using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Domain.Enums;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.Infra.Repositories;

public class PagadorRepository : GenericRepository<Pagador>, IPagadorRepository
{
    public PagadorRepository(RocketFinanceiraDbContext context) : base(context) { }

    public async Task<IEnumerable<Pagador>> ObterPagadoresPendentesDePagamentoAsync()
        => await _context.Pagadores
            .Where(p => p.Cobrancas.Any(c => c.StatusCobranca == StatusCobranca.Pendente))
            .ToListAsync();

    public async Task<Pagador> BuscarPorCPFAsync(string cpf)
        => await _context.Pagadores.FirstOrDefaultAsync(p => p.CPF == cpf);

    public async Task<IEnumerable<Pagador>> ObterPagadoresComCobrancasPendentesAsync()
        => await _context.Pagadores
            .Where(p => p.Cobrancas.Any(c => c.StatusCobranca == StatusCobranca.Pendente))
            .ToListAsync();
}
