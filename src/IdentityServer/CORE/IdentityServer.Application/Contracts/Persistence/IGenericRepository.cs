using System.Linq.Expressions;

namespace IdentityServer.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        Task<bool> Exists(Expression<Func<T, bool>> expression);
    }
}
