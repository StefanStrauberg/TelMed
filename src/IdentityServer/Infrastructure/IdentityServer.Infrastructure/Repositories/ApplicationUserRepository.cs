using BaseDomain.Specs;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        public Task<long> CountAsync(QuerySpecParams querySpecParams)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllAsync(QuerySpecParams querySpecParams)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
