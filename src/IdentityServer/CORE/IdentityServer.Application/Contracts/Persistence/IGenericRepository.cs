namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
    }
}
