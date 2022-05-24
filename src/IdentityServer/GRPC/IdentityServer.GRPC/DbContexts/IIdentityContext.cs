using MongoDB.Driver;

namespace IdentityServer.GRPC.DbContexts
{
    public interface IIdentityContext
    {
        IMongoCollection<Entities.ApplicationUser> Accounts { get; }
    }
}
