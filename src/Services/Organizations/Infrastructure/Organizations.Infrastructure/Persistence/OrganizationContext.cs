using MongoDB.Driver;
using Organizations.Domain;

namespace Organizations.Infrastructure.Persistence
{
    public class OrganizationContext : IOrganizationContext
    {
        public IMongoCollection<Organization> Organizations { get; }
    }
}
