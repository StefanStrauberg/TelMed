using Referrals.Domain.AnamnesisEntity;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IAnamnesisRepository
    {
        Task<bool> CreateAsync(Anamnesis entity, string ReferralId);
        Task<bool> UpdateAsync(Anamnesis entity, string ReferralId);
        Task<bool> DeleteAsync(Anamnesis entity, string ReferralId);
    }
}
