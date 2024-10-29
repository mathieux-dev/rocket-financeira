using RocketFinanceira.Domain.Enums;

namespace RocketFinanceira.Domain.Entities;

public class Notificacao
{
    public Guid Id { get; set; }
    public Guid PagadorId { get; set; }
    public Guid CobrancaId { get; set; }
    public TipoNotificacao Tipo { get; set; }
    public DateTime DataEnvio { get; set; }
    public required string Mensagem { get; set; }
    public bool Enviado { get; set; }

    public required Pagador Pagador { get; set; }
    public required Cobranca Cobranca { get; set; }
}
