namespace Anamnesies.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<string> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity, string id);
        Task<bool> DeleteAsync(string id);
    }
}
