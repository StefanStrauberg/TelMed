using BaseDomain;
using BaseDomain.Specifications;
using Microsoft.EntityFrameworkCore;
using Organizations.Application.Contracts.Persistence;
using System.Linq.Expressions;

namespace Organizations.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
    {
        protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
            => _context = context;
        public async Task Add(T entity)
            => await _context.Set<T>().AddAsync(entity);
        public async Task<int> CountAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).CountAsync();
        public async Task<IEnumerable<T>> FindWithExpressionAsync(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> FindWithSpecificationAsync(ISpecification<T> specification = null)
            => await ApplySpecification(specification).AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);
        public void Remove(T entity)
            => _context.Set<T>().Remove(entity);
        public void Update(T entity)
            => _context.Set<T>().Update(entity);
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
            => SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}
