using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Domain.Enums;

namespace RocketFinanceira.Application.Interfaces.Repositories;

public interface ICobrancaRepository : IGenericRepository<Cobranca>
{
    Task GerarCobrancaParaPagadorAsync(Guid pagadorId, Cobranca cobranca);
    Task<IEnumerable<Cobranca>> ObterCobrancasPorStatusAsync(StatusCobranca status);
    Task AtualizarStatusCobrancaAsync(Guid cobrancaId, StatusCobranca status);
    Task<IEnumerable<Cobranca>> ObterCobrancasPorIntervaloAsync(DateTime inicio, DateTime fim);
}
