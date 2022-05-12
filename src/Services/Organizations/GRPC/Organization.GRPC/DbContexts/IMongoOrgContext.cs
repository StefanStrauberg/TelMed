using MongoDB.Driver;

namespace Organization.GRPC.DbContexts
{
    public interface IMongoOrgContext
    {
        IMongoCollection<Entities.Organization> Organizations { get; }
    }
}
