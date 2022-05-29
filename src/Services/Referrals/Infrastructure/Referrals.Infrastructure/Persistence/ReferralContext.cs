using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Referrals.Domain.ReferralEntity;
using Referrals.Infrastructure.Persistence.Config;

namespace Referrals.Infrastructure.Persistence
{
    public class ReferralContext : IReferralContext
    {
        public IMongoCollection<Referral> Referrals { get; }
        public ReferralContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            Referrals = Databse.GetCollection<Referral>(dbOptions.Value.CollectionName);
        }
    }
}
