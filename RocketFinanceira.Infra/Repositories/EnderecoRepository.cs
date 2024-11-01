using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Domain.Entities;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.Infra.Repositories;

public class EnderecoRepository : GenericRepository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(RocketFinanceiraDbContext context) : base(context) { }

    public async Task<Endereco> BuscarPorCEPAsync(string cep)
        => await _context.Enderecos.FirstOrDefaultAsync(e => e.CEP == cep);

    public async Task<IEnumerable<Endereco>> ObterEnderecosPorCidadeAsync(string cidade)
        => await _context.Enderecos.Where(e => e.Cidade == cidade).ToListAsync();

    public async Task<Endereco> ObterEnderecoCompletoAsync(Guid enderecoId)
        => await _context.Enderecos.FindAsync(enderecoId);
}
