using MongoDB.Bson;
using MongoDB.Driver;
using Purposes.Application.Contracts.Persistence;
using Purposes.Domain;
using Purposes.Infrastructure.Persistence;

namespace Purposes.Infrastructure.Repositories
{
    public class PurposeRepository : IPurposeRepository
    {
        private readonly IPurposeContext _context;
        public PurposeRepository(IPurposeContext context)
            => _context = context;

        public async Task CreateAsync(Purpose entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Purposes.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Purposes
                .DeleteOneAsync(Builders<Purpose>.Filter.Eq(x => x.Id, id));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<Purpose>> GetAllAsync()
            => await _context.Purposes.Find(x => true).ToListAsync();

        public async Task<Purpose> GetAsync(string id)
            => await _context.Purposes.Find(Builders<Purpose>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(Purpose entity, string id)
        {
            var result = await _context.Purposes
                .UpdateOneAsync(
                Builders<Purpose>.Filter.Eq(x => x.Id, id),
                Builders<Purpose>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Resume, entity.Resume));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<Purpose>> GetAllAsyncByRefferalId(string id)
            => await _context.Purposes.Find(x => x.ReferralId == id).ToListAsync();
    }
}
