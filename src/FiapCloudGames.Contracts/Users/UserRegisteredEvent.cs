namespace FiapCloudGames.Contracts.Users;

/// <summary>
/// Publicado quando um usuário se auto-registra na plataforma.
/// </summary>
public record UserRegisteredEvent(
    Guid UserId,
    string Name,
    string Email) : IIntegrationEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();

    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}
