using RocketFinanceira.Domain.Entities;

namespace RocketFinanceira.Application.Interfaces.Repositories;

public interface IEnderecoRepository : IGenericRepository<Endereco>
{
    Task<Endereco> BuscarPorCEPAsync(string cep);
    Task<IEnumerable<Endereco>> ObterEnderecosPorCidadeAsync(string cidade);
    Task<Endereco> ObterEnderecoCompletoAsync(Guid enderecoId);
}
