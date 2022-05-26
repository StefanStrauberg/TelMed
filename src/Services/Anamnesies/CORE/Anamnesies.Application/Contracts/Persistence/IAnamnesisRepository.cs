using Anamnesies.Domain;

namespace Anamnesies.Application.Contracts.Persistence
{
    public interface IAnamnesisRepository : IGenericRepository<Anamnesis>
    {
        Task<string> GetReferralId(string id);
    }
}
