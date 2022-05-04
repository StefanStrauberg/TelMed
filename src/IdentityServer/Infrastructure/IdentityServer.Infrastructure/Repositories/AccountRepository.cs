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

        public async Task<string> GetHashByIdAsync(string id)
            => await _context.Set<Account>()
                .Where(x => x.Id == id)
                .Select(x => x.PasswordHash)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<string> GetSaltByOdAsync(string id)
            => await _context.Set<Account>()
                .Where(x => x.Id == id)
                .Select(x => x.PasswordSalt)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task SеtHashByAccount(Account model)
        {
            _context.Attach(model);
            _context.Entry(model).Property(x => x.PasswordHash).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task SеtSaltByAccount(Account model)
        {
            _context.Attach(model);
            _context.Entry(model).Property(x => x.PasswordSalt).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}