namespace FiapCloudGames.Contracts.Users;

/// <summary>
/// Publicado quando um administrador cria um usuário.
/// </summary>
public record UserCreatedEvent(
    Guid UserId,
    string Name,
    string Email,
    RoleType Role) : IIntegrationEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();

    public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
}