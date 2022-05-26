using Anamnesies.Domain;

namespace Anamnesies.Application.Contracts.Persistence
{
    public interface IAnamnesisRepository : IGenericRepository<Anamnesis>
    {
        Task<string> GetReferralId(string id);
        Task<IReadOnlyList<Anamnesis>> GetAllAsyncByRefferalId(string id);
        Task<bool> ContainsAnamnesisCategoryAsync(AnamnesisCategory CategoryId, string ReferralId);
    }
}
