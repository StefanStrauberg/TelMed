using MongoDB.Driver;
using Referrals.Domain.ReferralEntity;

namespace Referrals.Infrastructure.Persistence
{
    public interface IReferralContext
    {
        IMongoCollection<Referral> Referrals { get; }
    }
}
