using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Specializations.Domain;
using Specializations.Infrastructure.Persistence.Config;

namespace Specializations.Infrastructure.Persistence
{
    public class SpecializationContext : ISpecializationContext
    {
        public IMongoCollection<Specialization> Specializations { get; }
        public SpecializationContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Specializations = Databse.GetCollection<Specialization>(dbOptions.Value.CollectionName);
        }
    }
}
