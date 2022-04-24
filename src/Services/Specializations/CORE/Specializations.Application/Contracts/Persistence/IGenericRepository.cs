using Specializations.Application.Specs;

namespace Specializations.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync(QuerySpecParams querySpecParams);
        Task CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, string id);
        Task<bool> DeleteAsync(string Id);
        Task<long> CountAsync(QuerySpecParams querySpecParams);
    }
}
