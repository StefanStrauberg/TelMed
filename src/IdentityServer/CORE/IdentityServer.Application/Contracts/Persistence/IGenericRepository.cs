using IdentityServer.Application.Specs;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<T> GetAsync(Guid Id);
    }
}
