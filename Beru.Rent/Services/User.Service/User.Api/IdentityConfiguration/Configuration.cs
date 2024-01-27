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
            AccessTokenLifetime = 3600,
            SlidingRefreshTokenLifetime = 1296000,
            AllowedGrantTypes = GrantTypes.Code,
            RefreshTokenUsage = TokenUsage.OneTimeOnly,
            AllowedCorsOrigins = {"https://localhost:3000"},
            RedirectUris = { "https://localhost:3000/callback" },
            PostLogoutRedirectUris = { "https://localhost:3000/" },
            AllowedScopes =
            {
                "User.Api",
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OfflineAccess
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