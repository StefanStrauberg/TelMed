using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;
using Referrals.Domain.ReferralEntity;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IReferralRepository : IGenericRepository<Referral>
    {
        Task<bool> CreateAnamnesis(Anamnesis model, string referralId);
        Task<bool> UpdateAnamnesis(Anamnesis model, string referralId);
        Task<bool> RemoveAnamnesis(int anamnesisCategory, string referralId);
        Task<bool> AddPurpose(Purpose model, string referralId);
        Task<bool> UpdatePurpose(Purpose model, string referralId);
        Task<bool> RemovePurpose(int purposeGroup, string referralId);
    }
}
