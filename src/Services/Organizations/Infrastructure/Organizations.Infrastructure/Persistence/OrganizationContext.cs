using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Organizations.Domain;
using Organizations.Infrastructure.Persistence.Config;

namespace Organizations.Infrastructure.Persistence
{
    public class OrganizationContext : IOrganizationContext
    {
        public IMongoCollection<Organization> Organizations { get; }
        public OrganizationContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Organizations = Databse.GetCollection<Organization>(dbOptions.Value.CollectionName);
        }
    }
}
