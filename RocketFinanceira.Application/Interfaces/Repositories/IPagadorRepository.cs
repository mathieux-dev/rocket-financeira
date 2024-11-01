using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Application.Interfaces.Repositories;

public interface IPagadorRepository : IGenericRepository<Pagador>
{
    Task<IEnumerable<Pagador>> ObterPagadoresPendentesDePagamentoAsync();
    Task<Pagador> BuscarPorCPFAsync(string cpf);
    Task<IEnumerable<Pagador>> ObterPagadoresComCobrancasPendentesAsync();
}
