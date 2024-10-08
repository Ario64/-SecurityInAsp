using System.Security.Principal;
using IdentityServer8;
using IdentityServer8.Models;

namespace SecurityInAsp.TokenService;

public class Config
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "Role",
                UserClaims = new List<string>()
                {
                    "Role"
                }
            }

        };

    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>()
        {
            new Client()
            {
                ClientId = "RouxAcademy",
                ClientName = "Roux Academy Client",
                AllowedGrantTypes = GrantTypes.Implicit,
                RedirectUris = {"http://localhost:7945/signin-oidc"},
                PostLogoutRedirectUris = {"http://localhost:7945/signout-callback-oidc"},
                AllowedScopes = new List<string>()
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                }
            }
        };
    }
}