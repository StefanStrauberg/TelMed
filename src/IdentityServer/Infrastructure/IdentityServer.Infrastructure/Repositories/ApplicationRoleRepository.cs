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

        public async Task<List<ApplicationRole>> GetAllAsync()
            => await _context.Roles.Find(x => true).ToListAsync();

        public async Task<string> GetRoleNameById(string Id)
            => await _context.Roles
                .Find(Builders<ApplicationRole>.Filter.Eq(x => x.Id,new Guid(Id)))
                .Project(x => x.Name)
                .FirstOrDefaultAsync();

        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task<ApplicationRole> GetAsync(Guid Id)
            => await _context.Roles
                .Find(Builders<ApplicationRole>.Filter.Eq(x => x.Id, Id))
                .FirstOrDefaultAsync();
    }
}
