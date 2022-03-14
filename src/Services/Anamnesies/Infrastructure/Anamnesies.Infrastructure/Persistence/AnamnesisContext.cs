using Anamnesies.Domain;
using Anamnesies.Infrastructure.Persistence.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Anamnesies.Infrastructure.Persistence
{
    public class AnamnesisContext : IAnamnesisContext
    {
        public IMongoCollection<Anamnesis> Anamnesies { get; }
        public AnamnesisContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Anamnesies = Databse.GetCollection<Anamnesis>(dbOptions.Value.CollectionName);
        }
    }
}
