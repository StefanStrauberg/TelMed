using MongoDB.Driver;
using Referrals.Domain;

namespace Referrals.Infrastructure.Persistence
{
    public interface IReferralContext
    {
        IMongoCollection<Referral> Referrals { get; }
    }
}
