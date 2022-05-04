using IdentityServer.Domain;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IAccountRepository : IGenericRepository<Account> 
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(string id);
        Task<string> GetHashByIdAsync(string id);
        Task SеtHashByAccount(Account model);
        Task<string> GetSaltByOdAsync(string id);
        Task SеtSaltByAccount(Account model);
    }
}