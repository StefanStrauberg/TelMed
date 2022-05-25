using IdentityServer.GRPC.DbContexts.Config;
using IdentityServer.GRPC.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IdentityServer.GRPC.DbContexts
{
    public class IdentityContext : IIdentityContext
    {
        public IMongoCollection<ApplicationUser> Accounts { get; }

        [Obsolete]
        public IdentityContext(IOptions<DatabaseSettings> dbOptions)
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.GuidRepresentation = GuidRepresentation.Standard;
            settings.Server = new MongoServerAddress(dbOptions.Value.ConnectionString);
            var Client = new MongoClient(settings);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Accounts = Databse.GetCollection<ApplicationUser>(dbOptions.Value.CollectionName);
        }
    }
}
