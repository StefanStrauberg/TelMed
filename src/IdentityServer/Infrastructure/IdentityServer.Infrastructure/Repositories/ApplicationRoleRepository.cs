using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameById(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
