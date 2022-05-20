using Referrals.Application.Specs;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync(QuerySpecParams querySpecParams, string authorId);
        Task CreateAsync(T entity, string authorId);
        Task<bool> UpdateAsync(T entity, string Id);
        Task<bool> DeleteAsync(string Id);
        Task<long> CountAsync(QuerySpecParams querySpecParams, string authorId);
    }
}
