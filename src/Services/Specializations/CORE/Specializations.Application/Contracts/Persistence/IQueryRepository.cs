using BaseDomain.Specifications;
using System.Linq.Expressions;

namespace Specializations.Application.Contracts.Persistence
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> FindWithSpecificationAsync(ISpecification<T> specification = null);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
