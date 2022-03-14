using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Observations.Domain;
using Observations.Infrastructure.Persistence.Config;

namespace Observations.Infrastructure.Persistence
{
    public class ObservationContext : IObservationContext
    {
        public IMongoCollection<Observation> Observations  { get; }
        public ObservationContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Observations = Databse.GetCollection<Observation>(dbOptions.Value.CollectionName);
        }
    }
}
