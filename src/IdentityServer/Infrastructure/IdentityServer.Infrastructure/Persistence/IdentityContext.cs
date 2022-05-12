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
        public IdentityContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Accounts = Databse.GetCollection<ApplicationUser>(dbOptions.Value.CollectionNameAccounts);
            Roles = Databse.GetCollection<ApplicationRole>(dbOptions.Value.CollectionNameRoles);
        }
    }
}
