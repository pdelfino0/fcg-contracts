namespace FiapCloudGames.Contracts.Users;

/// <summary>
/// Nomes de exchange e routing keys dos eventos de usuário.
/// Compartilhados entre produtor (UsersAPI) e consumidores para evitar "magic strings".
/// </summary>
public static class UserMessaging
{
    /// <summary>Exchange (tipo topic) por onde trafegam os eventos de usuário.</summary>
    public const string Exchange = "users.exchange";

    public static class RoutingKeys
    {
        public const string Registered = "user.registered";
    }
}
