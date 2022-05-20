using MongoDB.Bson;
using MongoDB.Driver;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Specs;
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

        public async Task<IEnumerable<Referral>> GetAllAsync(QuerySpecParams querySpecParams, string authorId)
            => await _context.Referrals.Find(GetFilter(authorId))
                //.Skip((querySpecParams.PageIndex) * querySpecParams.PageSize)
                //.Limit(querySpecParams.PageSize)
                //.Sort(GetSort(querySpecParams.Sort))
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

        // Sort Referrals by Published Data
        private SortDefinition<Referral> GetSort(string sort) =>
            sort switch
            {
                "OrderByDescending" => Builders<Referral>.Sort.Descending(x => x.Published),
                _ => Builders<Referral>.Sort.Ascending(x => x.Published)
            };

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<long> CountAsync(QuerySpecParams querySpecParams, string authorId)
            => await _context.Referrals
                .Find(GetFilter(authorId))
                .CountDocumentsAsync();
    }
}
