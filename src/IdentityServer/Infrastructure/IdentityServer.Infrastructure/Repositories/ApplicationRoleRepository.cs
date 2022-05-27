using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using MongoDB.Driver;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly IIdentityContext _context;
        public ApplicationRoleRepository(IIdentityContext context)
            => _context = context;
        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task<List<ApplicationRole>> GetAllAsync()
            => await _context.Roles.Find(x => true).ToListAsync();

        public Task<ApplicationRole> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
