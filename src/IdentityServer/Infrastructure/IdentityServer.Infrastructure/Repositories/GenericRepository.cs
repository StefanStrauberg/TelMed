using System.Linq.Expressions;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IdentityUser
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
            => _context = context;
        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
            => await _context.Set<T>()
                .Where(expression)
                .AsNoTracking()
                .AnyAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}