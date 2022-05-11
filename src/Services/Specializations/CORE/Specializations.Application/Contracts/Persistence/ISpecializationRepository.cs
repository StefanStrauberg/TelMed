using Specializations.Domain;

namespace Specializations.Application.Contracts.Persistence
{
    public interface ISpecializationRepository : IGenericRepository<Specialization>
    {
        Task<Object> GetShortSpecializaitons();
    }
}
