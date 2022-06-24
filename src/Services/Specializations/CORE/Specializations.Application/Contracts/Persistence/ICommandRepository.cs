using BaseDomain.Specifications;
using System.Linq.Expressions;

namespace Specializations.Application.Contracts.Persistence
{
    public interface ICommandRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(Guid id);
    }
}
