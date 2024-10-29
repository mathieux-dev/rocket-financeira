namespace RocketFinanceira.Domain.Entities;

public class Endereco
{
    public Guid Id { get; set; }
    public required string Rua { get; set; }
    public required string Numero { get; set; }
    public string? Complemento { get; set; }
    public required string Cidade { get; set; }
    public required string Estado { get; set; }
    public required string CEP { get; set; }
}
