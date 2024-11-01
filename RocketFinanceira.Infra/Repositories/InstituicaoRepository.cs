using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.Infra.Repositories;

public class InstituicaoRepository : GenericRepository<Instituicao>, IInstituicaoRepository
{
    public InstituicaoRepository(RocketFinanceiraDbContext context) : base(context) { }

    public async Task<IEnumerable<Instituicao>> BuscarInstituicoesAtivasAsync()
        => await _context.Instituicoes.Where(i => i.Ativo).ToListAsync();

    public async Task<Instituicao> ObterInstituicaoPorCNPJAsync(string cnpj)
        => await _context.Instituicoes.FirstOrDefaultAsync(i => i.CNPJ == cnpj);

    public async Task<IEnumerable<Pagador>> ObterPagadoresPorInstituicaoAsync(Guid instituicaoId)
        => await _context.Pagadores.Where(p => p.Id == instituicaoId).ToListAsync();
}
