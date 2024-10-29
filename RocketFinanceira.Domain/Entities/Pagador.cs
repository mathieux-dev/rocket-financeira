using RocketFinanceira.Domain.Enums;

namespace RocketFinanceira.Domain.Entities;

public class Pagador
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string CPF { get; set; }
    public required Instituicao Instituicao { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<Cobranca> Cobrancas { get; set; } = [];
}
