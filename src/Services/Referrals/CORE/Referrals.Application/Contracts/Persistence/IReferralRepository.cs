using MessageBus;
using Referrals.Domain;

namespace Referrals.Application.Contracts.Persistence
{
    public interface IReferralRepository : IGenericRepository<Referral>
    {
        Task<bool> AddAnamnesis(Message message);
        Task<bool> RemoveAnamnesis(Message message);
    }
}
