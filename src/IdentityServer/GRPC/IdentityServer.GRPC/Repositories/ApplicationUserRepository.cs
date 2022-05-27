using IdentityServer.Infrastructure.Persistence;

namespace IdentityServer.GRPC.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IIdentityContext _context;
        public ApplicationUserRepository(IIdentityContext context)
            => _context = context;
        public async Task<string> GetAccNameAsync(string Id)
            => "123";
            // => await _context.Accounts
            //     .Find(Builders<ApplicationUser>.Filter.Eq(x => x.Id, new Guid(Id)))
            //     .Project(x => x.LastName + " " + x.FirstName + " " + x.MiddleName)
            //     .FirstOrDefaultAsync();
        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}
