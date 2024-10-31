using RocketFinanceira.Domain.Enums;

namespace RocketFinanceira.Domain.Entities;

public class Cobranca
{
    public Cobranca() { }

    public Guid Id { get; set; }
    public TipoCobranca TipoCobranca { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
    public StatusCobranca StatusCobranca { get; set; }
    public bool Recorrente { get; set; }
    public IntervaloRecorrencia IntervaloRecorrencia { get; set; }
    public DateTime DataCobranca { get; set; }
    public decimal Valor { get; set; }
    public required Pagador Pagador { get; set; }
}
