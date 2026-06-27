namespace FiapCloudGames.Contracts;

/// <summary>
/// Contrato base para todos os eventos de integração publicados entre microsserviços.
/// Carrega metadados comuns de rastreabilidade.
/// </summary>
public interface IIntegrationEvent
{
    /// <summary>Identificador único do evento (idempotência / deduplicação no consumidor).</summary>
    Guid EventId { get; }

    /// <summary>Momento (UTC) em que o evento ocorreu.</summary>
    DateTime OccurredAt { get; }
}
