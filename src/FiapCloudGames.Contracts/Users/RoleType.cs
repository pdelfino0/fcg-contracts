namespace FiapCloudGames.Contracts.Users;

/// <summary>
/// Papel (role) do usuário, compartilhado entre produtor e consumidores.
/// Os valores devem permanecer estáveis: representam o contrato na fila.
/// </summary>
public enum RoleType
{
    User = 1,
    Administrator = 2
}
