using Purposes.Domain;

namespace Purposes.Application.Contracts.Persistence
{
    public interface IPurposeRepository : IGenericRepository<Purpose>
    {
        Task<IReadOnlyList<Purpose>> GetAllAsyncByRefferalId(string id);
    }
}
