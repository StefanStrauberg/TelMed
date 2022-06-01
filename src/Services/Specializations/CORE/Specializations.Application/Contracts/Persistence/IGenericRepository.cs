using BaseDomain.Specifications;
using System.Linq.Expressions;

namespace Specializations.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindWithExpressionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindWithSpecificationAsync(ISpecification<T> specification = null);
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
