using MongoDB.Bson;
using MongoDB.Driver;
using Observations.Application.Contracts.Persistence;
using Observations.Domain;
using Observations.Infrastructure.Persistence;

namespace Observations.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationsRepository, IDisposable
    {
        private readonly IObservationContext _context;
        public ObservationRepository(IObservationContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(Observation entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Observations.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Observation>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Observations.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<Observation>> GetAllAsync()
        {
            return await _context.Observations.Find(x => true).ToListAsync();
        }

        public async Task<Observation> GetAsync(string Id)
        {
            var filter = Builders<Observation>.Filter.Eq(x => x.Id, Id);
            return await _context.Observations.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Observation entity)
        {
            var filter = Builders<Observation>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<Observation>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Description, entity.Description)
                .Set(x => x.Attachments, entity.Attachments);
            var result = await _context.Observations.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
