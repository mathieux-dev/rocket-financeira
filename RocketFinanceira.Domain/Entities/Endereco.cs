namespace RocketFinanceira.Domain.Entities;

public class Endereco
{
    public Endereco() { }

    public Guid Id { get; set; }
    public required string Logradouro { get; set; }
    public required string Numero { get; set; }
    public string? Complemento { get; set; } = "N/A";
    public required string Bairro { get; set; }
    public required string Cidade { get; set; }
    public required string Estado { get; set; }
    public required string CEP { get; set; }
}
