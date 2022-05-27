namespace Purposes.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T> GetAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, string id);
        Task<bool> DeleteAsync(string id);
    }
}
