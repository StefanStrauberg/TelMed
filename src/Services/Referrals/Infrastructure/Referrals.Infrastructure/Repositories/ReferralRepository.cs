using MessageBus;
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

        public async Task CreateAsync(Referral entity, string authorId)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            entity.AuthorId = new Guid(authorId);
            await _context.Referrals.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Referrals.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Referral>> GetAllAsync(string authorId)
            => await _context.Referrals.Find(GetFilter(authorId))
                .ToListAsync();

        public async Task<Referral> GetAsync(string Id)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, Id);
            return await _context.Referrals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Referral entity, string Id)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Patient.FullName, entity.Patient.FullName)
                .Set(x => x.Patient.Gender, entity.Patient.Gender)
                .Set(x => x.Patient.BirthDate, entity.Patient.BirthDate);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        // Find referrral by AuthorId
        private FilterDefinition<Referral> GetFilter(string authorId)
            => Builders<Referral>.Filter.Eq(x => x.AuthorId, new Guid(authorId));

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> AddAnamnesis(Message message)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, message.ReferralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Push(x => x.Anamnesis, message.DataId);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAnamnesis(Message message)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, message.ReferralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Pull(x => x.Anamnesis, message.DataId);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
