using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Purposes.Domain;
using Purposes.Infrastructure.Persistence.Config;

namespace Purposes.Infrastructure.Persistence
{
    public class PurposeContext : IPurposeContext
    {
        public IMongoCollection<Purpose> Purposes { get; }
        public PurposeContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Purposes = Databse.GetCollection<Purpose>(dbOptions.Value.CollectionName);
        }
    }
}
