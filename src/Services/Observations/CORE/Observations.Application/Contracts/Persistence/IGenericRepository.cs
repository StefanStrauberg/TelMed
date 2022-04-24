using Observations.Application.Specs;

namespace Observations.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string Id);
        Task<IReadOnlyList<T>> GetAllAsync(QuerySpecParams querySpecParams);
        Task CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, string Id);
        Task<bool> DeleteAsync(string Id);
        Task<long> CountAsync(QuerySpecParams querySpecParams);
    }
}
