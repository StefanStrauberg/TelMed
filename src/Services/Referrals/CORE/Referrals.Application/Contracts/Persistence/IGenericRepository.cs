namespace Referrals.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync(string authorId);
        Task CreateAsync(T entity, string authorId);
        Task<bool> UpdateAsync(T entity, string Id);
        Task<bool> DeleteAsync(string Id);
    }
}
