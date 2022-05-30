using BaseDomain.Specs;
using IdentityServer.Domain;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<long> CountAsync(QuerySpecParams querySpecParams);
        Task<List<ApplicationUser>> GetAllAsync(QuerySpecParams querySpecParams);
    }
}
