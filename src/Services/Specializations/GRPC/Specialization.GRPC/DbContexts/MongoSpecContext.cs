using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Specialization.GRPC.DbContexts.Config;

namespace Specialization.GRPC.DbContexts
{
    public class MongoSpecContext : IMongoSpecContext
    {
        public IMongoCollection<Specialization.GRPC.Entities.Specialization> Specializations { get; }
        public MongoSpecContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Specializations = Databse.GetCollection<Specialization.GRPC.Entities.Specialization>(dbOptions.Value.CollectionName);
        }
    }
}
