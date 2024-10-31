namespace RocketFinanceira.Domain.Entities;

public class Pagador
{
    public Pagador() { }

    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string CPF { get; set; }
    public required Endereco Endereco { get; set; }
    public required Contato Contato { get; set; }
    public required Instituicao Instituicao { get; set; }
    public DateTime DataNascimento { get; set; }
    public ICollection<Cobranca> Cobrancas { get; set; } = [];
}
