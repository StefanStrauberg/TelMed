using IdentityServer4.Models;
using System.Collections.Generic;

namespace TelMed.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("orgAPI", "Organization API")
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                  ClientId = "orgClient",
                  ClientSecrets = { new Secret("SecretOrgApi".Sha256()) },
                  AllowedGrantTypes = GrantTypes.ClientCredentials,
                  AllowedScopes = { "orgAPI" }
                }
            };
    }
}
