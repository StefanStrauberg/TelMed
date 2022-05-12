using IdentityServer.Domain;
using MongoDB.Driver;

namespace IdentityServer.Infrastructure.Persistence
{
    public interface IIdentityContext
    {
        IMongoCollection<ApplicationUser> Accounts { get; }
        IMongoCollection<ApplicationRole> Roles { get; }
    }
}
