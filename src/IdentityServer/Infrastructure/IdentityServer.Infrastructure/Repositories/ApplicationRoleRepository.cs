using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        private readonly RepositoryContext _context;
        public ApplicationRoleRepository(RepositoryContext context)
            => _context = context;
        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task<List<ApplicationRole>> GetAllAsync()
            => await _context.ApplicationRoles.AsNoTracking().ToListAsync();

        public async Task<ApplicationRole> GetAsync(Guid id)
            => await _context.ApplicationRoles.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

        public async Task<string> GetRoleNameByIdAsync(Guid id)
            => await _context.ApplicationRoles.Where(x => x.Id == id).AsNoTracking().Select(x => x.Name).FirstOrDefaultAsync();
    }
}
