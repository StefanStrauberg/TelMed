using MongoDB.Bson;
using MongoDB.Driver;
using Referrals.Application.Contracts.Persistence;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;
using Referrals.Domain.ReferralEntity;
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

        // Find Referrral by AuthorId
        private FilterDefinition<Referral> GetFilter(string authorId)
            => Builders<Referral>.Filter.Eq(x => x.AuthorId, new Guid(authorId));

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // Referral Anamnesis
        public async Task<bool> CreateAnamnesis(Anamnesis model, string referralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Push(x => x.Anamnesis, model);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAnamnesis(string referralId, int anamnesisCategoryId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .PullFilter(x => x.Anamnesis, item => item.CategoryId == (AnamnesisCategory)anamnesisCategoryId);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> UpdateAnamnesis(Anamnesis model, string referralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId) &
                Builders<Referral>.Filter.ElemMatch(doc => doc.Anamnesis, el => el.CategoryId == model.CategoryId);
            var update = Builders<Referral>.Update.Set(doc => doc.Anamnesis[-1].Summary, model.Summary);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<Anamnesis> GetAnamnesisByReferralIdAndAnamnesisCategoryId(string referralId, int anamnesisCategoryId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            return await _context.Referrals.Find(filter)
                .Project(x => x.Anamnesis
                    .Where(x => x.CategoryId == (AnamnesisCategory)anamnesisCategoryId).FirstOrDefault())
                    .FirstOrDefaultAsync();
        }

        // Referral Purpose
        public async Task<bool> CreatePurpose(Purpose model, string referralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Push(x => x.Purpose, model);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> UpdatePurpose(Purpose model, string referralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId) &
                Builders<Referral>.Filter.ElemMatch(doc => doc.Purpose, el => el.Group == model.Group);
            var update = Builders<Referral>.Update.Set(doc => doc.Purpose[-1].Resume, model.Resume);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemovePurpose(string referralId, int purposeGroupId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            var update = Builders<Referral>.Update
                .Set(x => x.Updated, DateTime.Now)
                .PullFilter(x => x.Purpose, item => item.Group == (PurposeGroup)purposeGroupId);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<Purpose> GetPurposeByReferralIdAndPurposeGroupId(string referralId, int purposeGroupId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, referralId);
            return await _context.Referrals.Find(filter)
                .Project(x => x.Purpose
                    .Where(x => x.Group == (PurposeGroup)purposeGroupId).FirstOrDefault())
                    .FirstOrDefaultAsync();
        }
    }
}
