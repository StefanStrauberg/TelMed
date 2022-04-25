using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer.Configuration
{
    public class InMemoryConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static List<TestUser> GetTestUsers() =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "70312217-5f95-443b-b6b0-1edb177e224c",
                    Username = "Admin",
                    Password = "!QAZxsw2",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name","Admin User"),
                        new Claim("family_name","Administrator")
                    }
                }
            };
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "SpecializationApi",
                    ClientSecrets = new[] { new Secret("secret".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId
                    }
                }
            };
    }
}