using IdentityServer.Domain;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole>
    {
        Task<List<ApplicationRole>> GetAllAsync();
        Task<string> GetRoleNameByIdAsync(Guid id);
    }
}
