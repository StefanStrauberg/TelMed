using Referrals.Domain;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IReferralRepository
    {
        Task<Referral> GetAsync(string Id);
        Task<IReadOnlyList<Referral>> GetAllAsync();
        Task<string> CreateAsync(Referral entity);
        Task<bool> DeleteAsync(string Id);
    }
}
