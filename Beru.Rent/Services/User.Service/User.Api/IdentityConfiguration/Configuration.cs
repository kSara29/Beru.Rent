using IdentityServer4;
using IdentityServer4.Models;

namespace User.Api.IdentityConfiguration;

public static class Configuration
{
    public static IEnumerable<Client> GetClients() => new List<Client>
    {
        new()
        {
            ClientId = "client_id_vue",
            RequireClientSecret = false,
            RequireConsent = false,
            RequirePkce = true,
            AllowOfflineAccess = true,
            AllowedGrantTypes = GrantTypes.Code,
            AllowedCorsOrigins = {"https://localhost:7034"},
            RedirectUris = { "https://localhost:7034/callback.html" },
            AllowedScopes =
            {
                "User.Api",
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            }
        }
    };

    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new("User.Api", "My User Api")
            {
                Scopes = {"User.Api"}
            }
        };

    public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> GetScopes()
    {
        return new List<ApiScope>
        {
            new("User.Api", "User.Api")
        };
    }
}