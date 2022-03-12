using MongoDB.Bson;
using MongoDB.Driver;
using Referrals.Application.Contracts.Persistence;
using Referrals.Domain;
using Referrals.Infrastructure.Persistence;

namespace Referrals.Infrastructure.Repositories
{
    public class ReferralRepository : IReferralRepository, IDisposable
    {
        private readonly IReferralContext _context;
        public ReferralRepository(IReferralContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(Referral entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Referrals.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Referrals.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<Referral>> GetAllAsync()
        {
            return await _context.Referrals.Find(x => true).ToListAsync();
        }

        public async Task<Referral> GetAsync(string Id)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, Id);
            return await _context.Referrals.Find(filter).FirstOrDefaultAsync();
        }
    }
}
