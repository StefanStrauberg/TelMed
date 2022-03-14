namespace Observations.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string Id);
    }
}
