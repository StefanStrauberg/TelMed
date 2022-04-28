using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ApplicationContext _context;
        public AccountRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
            => await _context.Set<Account>()
                .Include(x => x.Role)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Account> GetByIdAsync(string id)
            => await _context.Set<Account>()
                .Where(a => a.Id == id)
                .Include(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync();

    }
}