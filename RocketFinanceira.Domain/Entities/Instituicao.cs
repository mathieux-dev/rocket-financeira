namespace RocketFinanceira.Domain.Entities;

public class Instituicao
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string CNPJ { get; set; }
    public required string Endereco { get; set; }
    public required Contato Contato { get; set; }
}
