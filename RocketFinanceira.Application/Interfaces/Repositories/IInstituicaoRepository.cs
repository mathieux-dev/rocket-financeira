using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Application.Interfaces.Repositories;

public interface IInstituicaoRepository : IGenericRepository<Instituicao>
{
    Task<IEnumerable<Instituicao>> BuscarInstituicoesAtivasAsync();
    Task<Instituicao> ObterInstituicaoPorCNPJAsync(string cnpj);
    Task<IEnumerable<Pagador>> ObterPagadoresPorInstituicaoAsync(Guid instituicaoId);
}
