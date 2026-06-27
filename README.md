# FiapCloudGames.Contracts

Contratos de **eventos de integração** compartilhados entre os microsserviços do FIAP Cloud Games.

Distribuído como pacote NuGet ([nuget.org](https://www.nuget.org/packages/FiapCloudGames.Contracts)) para que produtor e consumidores usem **a mesma definição** de mensagem e roteamento.

## Instalação

```bash
dotnet add package FiapCloudGames.Contracts
```

## Conteúdo

| Tipo | Descrição |
|------|-----------|
| `IIntegrationEvent` | Contrato base (EventId, OccurredAt) de todo evento. |
| `Users.UserRegisteredEvent` | Usuário se auto-registrou. |
| `Users.UserCreatedEvent` | Administrador criou um usuário. |
| `Users.UserMessaging` | Nome da exchange e routing keys dos eventos de usuário. |

## Uso

**Produtor** (UsersAPI) serializa e publica:

```csharp
var evt = new UserRegisteredEvent(user.Id, user.Name, user.Email, user.RoleId);
// publica em UserMessaging.Exchange com routing key UserMessaging.RoutingKeys.Registered
```

**Consumidor** desserializa o mesmo tipo:

```csharp
var evt = JsonSerializer.Deserialize<UserRegisteredEvent>(body);
```

## Versionamento

Segue [SemVer](https://semver.org). Contratos são `record` imutáveis:

- Campo novo opcional → **minor/patch**.
- Renomear/remover campo → **major** (quebra consumidores).

## Publicação

Automática via GitHub Actions: ao publicar uma **release** com tag `vX.Y.Z`, o pacote
`X.Y.Z` é enviado ao nuget.org. Requer o secret `NUGET_API_KEY` configurado no repositório.

```bash
# Publicação manual (alternativa)
dotnet pack src/FiapCloudGames.Contracts/FiapCloudGames.Contracts.csproj -c Release -o out /p:Version=1.0.0
dotnet nuget push "out/*.nupkg" --api-key <API_KEY> --source https://api.nuget.org/v3/index.json
```
