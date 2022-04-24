using MongoDB.Bson;
using MongoDB.Driver;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Specs;
using Observations.Domain;
using Observations.Infrastructure.Persistence;

namespace Observations.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationsRepository, IDisposable
    {
        private readonly IObservationContext _context;
        public ObservationRepository(IObservationContext context)
            => _context = context;

        public async Task<long> CountAsync(QuerySpecParams querySpecParams)
            => await _context.Observations
                .Find(x => true).CountDocumentsAsync();

        public async Task CreateAsync(Observation entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Observations.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var result = await _context.Observations
                .DeleteOneAsync(Builders<Observation>.Filter.Eq(x => x.Id, Id));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<Observation>> GetAllAsync(QuerySpecParams querySpecParams)
            => await _context.Observations.Find(x => true)
                .Skip((querySpecParams.PageIndex - 1) * querySpecParams.PageSize)
                .Limit(querySpecParams.PageSize)
                .ToListAsync();

        public async Task<Observation> GetAsync(string Id)
            => await _context.Observations
                .Find(Builders<Observation>.Filter.Eq(x => x.Id, Id))
                .FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(Observation entity, string Id)
        {
            var result = await _context.Observations
                .UpdateOneAsync(
                    Builders<Observation>.Filter.Eq(x => x.Id, Id),
                    Builders<Observation>.Update
                    .Set(x => x.Updated, DateTime.Now)
                    .Set(x => x.Description, entity.Description)
                    .Set(x => x.Attachments, entity.Attachments));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
