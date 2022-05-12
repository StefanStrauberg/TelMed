using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Organization.GRPC.DbContexts.Config;

namespace Organization.GRPC.DbContexts
{
    public class MongoOrgContext : IMongoOrgContext
    {
        public IMongoCollection<Entities.Organization> Organizations { get; }
        public MongoOrgContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Organizations = Databse.GetCollection<Entities.Organization>(dbOptions.Value.CollectionName);
        }
    }
}
