using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Application.Configuration
{
    public class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
               new Client
               {
                    ClientName = "Angular-Client",
                    ClientId = "angular-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "http://localhost:4200/signin-callback", "http://localhost:4200/assets/silent-callback.html" },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        "SpecializationApiScope",
                        "OrganizationApiScope",
                        "ReferralsApiScope"
                    },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    RequireClientSecret = false,
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
                    RequireConsent = false,
                    AccessTokenLifetime = 600
                }
            };
        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> {
                new ApiScope("SpecializationApiScope", "Scope for SpecializationApi"),
                new ApiScope("OrganizationApiScope", "Scope for OrganizationApi"),
                new ApiScope("ReferralsApiScope", "Scope for ReferralsApi"),
            };
        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("SpecializationApi", "Specialization API")
                {
                    Scopes = { "SpecializationApiScope" }
                },
                new ApiResource("OrganizationApi", "Organization API")
                {
                    Scopes = { "OrganizationApiScope" }
                },
                new ApiResource("ReferralsApi", "Referrals API")
                {
                    Scopes = { "ReferralsApiScope" }
                }
            };
    }
}
