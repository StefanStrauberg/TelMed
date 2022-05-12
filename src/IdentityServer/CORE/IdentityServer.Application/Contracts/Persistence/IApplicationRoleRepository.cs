using IdentityServer.Domain;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole>
    {
        Task<string> GetRoleNameById(string Id);
        Task<List<ApplicationRole>> GetAllAsync();
    }
}
