using MongoDB.Driver;
using Referrals.Application.Contracts.Persistence;
using Referrals.Domain;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Infrastructure.Persistence;

namespace Referrals.Infrastructure.Repositories
{
    public class AnamnesisRepository : IAnamnesisRepository, IDisposable
    {
        private readonly IReferralContext _context;
        public AnamnesisRepository(IReferralContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Anamnesis entity, string ReferralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, ReferralId);
            var create = Builders<Referral>.Update.Push<Anamnesis>(x => x.Anamnesis, entity);
            var result = await _context.Referrals.UpdateOneAsync(filter, create);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(Anamnesis entity, string ReferralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, ReferralId);
            var delete = Builders<Referral>.Update.PullFilter(x => x.Anamnesis, 
                Builders<Anamnesis>.Filter.Eq(x => x.CategoryId, entity.CategoryId));
            var result = await _context.Referrals.UpdateOneAsync(filter, delete);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<bool> UpdateAsync(Anamnesis entity, string ReferralId)
        {
            var filter = Builders<Referral>.Filter.Eq(x => x.Id, ReferralId) &
                Builders<Referral>.Filter.ElemMatch(x => x.Anamnesis, 
                Builders<Anamnesis>.Filter.Eq(x => x.CategoryId, entity.CategoryId));
            var update = Builders<Referral>.Update.Set(x => x.Anamnesis[-1], entity);
            var result = await _context.Referrals.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
