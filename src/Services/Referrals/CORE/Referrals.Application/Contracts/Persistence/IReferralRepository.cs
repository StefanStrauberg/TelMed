using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;
using Referrals.Domain.ReferralEntity;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IReferralRepository : IGenericRepository<Referral>
    {
        Task<Anamnesis> GetAnamnesisByReferralIdAndAnamnesisCategoryId(string referralId, int anamnesisCategoryId);
        Task<Purpose> GetPurposeByReferralIdAndPurposeGroupId(string referralId, int purposeGroupId);
        Task<bool> CreateAnamnesis(Anamnesis model, string referralId);
        Task<bool> UpdateAnamnesis(Anamnesis model, string referralId);
        Task<bool> RemoveAnamnesis(string referralId, int anamnesisCategoryId);
        Task<bool> CreatePurpose(Purpose model, string referralId);
        Task<bool> UpdatePurpose(Purpose model, string referralId);
        Task<bool> RemovePurpose(string referralId, int purposeGroupId);
    }
}
