using Organizations.Application.Contracts.Persistence;
using Organizations.Domain.Common;

namespace Organizations.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IGenericRepository<T> where T : BaseDomainEntity
    {
        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
