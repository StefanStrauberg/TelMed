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

        public async Task CreateAsync(Referral entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Referrals.InsertOneAsync(entity);
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

        public async Task<bool> UpdateAsync(Referral entity)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Patient.FullName, entity.Patient.FullName)
                .Set(x => x.Patient.Gender, entity.Patient.Gender)
                .Set(x => x.Patient.BirthDate, entity.Patient.BirthDate);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
