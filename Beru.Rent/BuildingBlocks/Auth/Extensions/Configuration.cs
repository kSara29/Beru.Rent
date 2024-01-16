using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Auth.Extensions;

public static class Configuration
{
    public static IEnumerable<Client> GetClients() => new List<Client>
    {
        new()
        {
            ClientId = "client_id_mvc",
            ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            AllowedScopes =
            {
                "User.Api", 
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            },
            RedirectUris = { "https://localhost:7258/signin-oidc" },
            RequireConsent = false,
            // AlwaysIncludeUserClaimsInIdToken = true
        },
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