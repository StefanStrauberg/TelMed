using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.GRPC.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly RepositoryContext _context;
        public ApplicationUserRepository(RepositoryContext context)
            => _context = context;
        public async Task<string> GetAccNameAsync(string Id)
            => await _context.ApplicationUsers
                .Where(x => x.Id == new Guid(Id))
                .Select(x => x.LastName + " " + x.FirstName + " " + x.MiddleName).FirstOrDefaultAsync();
        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}
