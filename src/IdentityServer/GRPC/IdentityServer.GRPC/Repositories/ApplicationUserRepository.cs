using IdentityServer.GRPC.DbContexts;
using IdentityServer.GRPC.Entities;
using MongoDB.Driver;

namespace IdentityServer.GRPC.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IIdentityContext _context;
        public ApplicationUserRepository(IIdentityContext context)
            => _context = context;
        public async Task<string> GetAccNameAsync(string Id)
        {
            var test = await _context.Accounts.Find(Builders<ApplicationUser>.Filter.Eq(x => x.Id, new Guid(Id))).FirstOrDefaultAsync();
            var result = await _context.Accounts
                .Find(Builders<ApplicationUser>.Filter.Eq(x => x.Id, new Guid(Id)))
                .Project(x => x.LastName + " " + x.FirstName + " " + x.MiddleName)
                .FirstOrDefaultAsync();
            return result;
        }
        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}
