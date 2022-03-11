using MongoDB.Driver;
using Organizations.Domain;

namespace Organizations.Infrastructure.Persistence
{
    public interface IOrganizationContext
    {
        IMongoCollection<Organization> Organizations { get; }
    }
}
