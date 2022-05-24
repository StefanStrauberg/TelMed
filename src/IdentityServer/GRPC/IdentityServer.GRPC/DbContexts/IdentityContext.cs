using IdentityServer.GRPC.DbContexts.Config;
using IdentityServer.GRPC.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IdentityServer.GRPC.DbContexts
{
    public class IdentityContext : IIdentityContext
    {
        public IMongoCollection<ApplicationUser> Accounts { get; }
        public IdentityContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Accounts = Databse.GetCollection<ApplicationUser>(dbOptions.Value.CollectionNameAccounts);
        }
    }
}
