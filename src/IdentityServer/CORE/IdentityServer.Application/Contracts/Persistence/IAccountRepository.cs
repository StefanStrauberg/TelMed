using IdentityServer.Domain;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IAccountRepository : IGenericRepository<Account> 
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(string id);
    }
}