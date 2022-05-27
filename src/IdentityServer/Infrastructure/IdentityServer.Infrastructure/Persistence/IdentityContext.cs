using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer.Infrastructure.Persistence
{
    public class IdentityContext : IIdentityContext
    {
        public IMongoCollection<ApplicationUser> Accounts { get; }
        public IMongoCollection<ApplicationRole> Roles { get; }
        public IdentityContext(IOptions<MongoDbConfig> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.Name);
            Accounts = Databse.GetCollection<ApplicationUser>("applicationRoles");
            Roles = Databse.GetCollection<ApplicationRole>("applicationUsers");
        }
    }
}
