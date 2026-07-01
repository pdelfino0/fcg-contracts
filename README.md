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
var evt = new UserRegisteredEvent(user.Id, user.Name, user.Email);
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
`X.Y.Z` é enviado ao nuget.org. A autenticação usa **Trusted Publishing (OIDC)** — não há
API key de longa duração armazenada. Pré-requisitos (uma vez):

1. Em nuget.org → **Trusted Publishing**, crie uma policy: Repository Owner `pdelfino0`,
   Repository `fcg-contracts`, Workflow File `publish.yml` (sem Environment).
2. Defina o secret `NUGET_USER` no repositório com seu nome de usuário (profile) do nuget.org.

```bash
# Publicação manual (alternativa)
dotnet pack src/FiapCloudGames.Contracts/FiapCloudGames.Contracts.csproj -c Release -o out /p:Version=1.0.0
dotnet nuget push "out/*.nupkg" --api-key <API_KEY> --source https://api.nuget.org/v3/index.json
```
