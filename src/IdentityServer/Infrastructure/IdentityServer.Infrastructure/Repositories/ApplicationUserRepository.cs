using BaseDomain.Specs;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly RepositoryContext _context;
        public ApplicationUserRepository(RepositoryContext context)
            => _context = context;
        public Task<long> CountAsync(QuerySpecParams querySpecParams)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
            => GC.SuppressFinalize(this);

        public Task<List<ApplicationUser>> GetAllAsync(QuerySpecParams querySpecParams)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
            => await _context.ApplicationUsers.Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .AsNoTracking()
                .ToListAsync();

        public async Task<ApplicationUser> GetAsync(Guid id)
            => await _context.ApplicationUsers.Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
            => await _context.ApplicationUsers.Where(x => x.Id == id)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();
    }
}
