using IdentityServer.GRPC.Entities;
using MongoDB.Driver;

namespace IdentityServer.GRPC.DbContexts
{
    public interface IIdentityContext
    {
        IMongoCollection<ApplicationUser> Accounts { get; }
    }
}
