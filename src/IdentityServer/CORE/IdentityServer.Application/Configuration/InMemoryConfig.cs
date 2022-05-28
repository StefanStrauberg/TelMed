using IdentityServer4;
using IdentityServer4.Models;

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
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpecializationApi",
                        "OrganizationApi",
                        "ReferralsApi",
                        "AnamnesiesApi",
                        "PurposeApi"
                    },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    RequireClientSecret = false,
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
                    RequireConsent = false,
                    AccessTokenLifetime = 600
                },
                new Client
                {
                    ClientId = "ExternalApi",
                    ClientSecrets = new [] { new Secret("ExternalApiSuperPassword".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpecializationApi",
                        "OrganizationApi",
                        "ReferralsApi",
                        "AnamnesiesApi",
                        "PurposeApi"
                    }
                }
            };
        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> {
                new ApiScope("SpecializationApi", "Full access for SpecializationApi"),
                new ApiScope("OrganizationApi", "Full access for OrganizationApi"),
                new ApiScope("ReferralsApi", "Full access for ReferralsApi"),
                new ApiScope("AnamnesiesApi", "Full access for AnamnesiesApi"),
                new ApiScope("PurposeApi", "Full access for PurposeApi"),
            };
        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("SpecializationApi", "Specialization API")
                {
                    Scopes = { "SpecializationApi" }
                },
                new ApiResource("OrganizationApi", "Organization API")
                {
                    Scopes = { "OrganizationApi" }
                },
                new ApiResource("ReferralsApi", "Referrals API")
                {
                    Scopes = { "ReferralsApi" }
                },
                new ApiResource("AnamnesiesApi", "Anamnesies API")
                {
                    Scopes = { "AnamnesiesApi" }
                },
                new ApiResource("PurposeApi", "Purpose API")
                {
                    Scopes = { "PurposeApi" }
                }
            };
    }
}
