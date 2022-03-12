using MongoDB.Bson;
using MongoDB.Driver;
using Specializations.Application.Contracts.Persistence;
using Specializations.Domain;
using Specializations.Infrastructure.Persistence;

namespace Specializations.Infrastructure.Repositories
{
    public class SpecializationRepository : ISpecializationRepository, IDisposable
    {
        private readonly ISpecializationContext _context;
        public SpecializationRepository(ISpecializationContext context)
        {
            _context = context;
        }
        public async Task<string> CreateAsync(Specialization entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Specializations.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Specialization>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Specializations.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<Specialization>> GetAllAsync()
        {
            return await _context.Specializations.Find(x => true).ToListAsync();
        }

        public async Task<Specialization> GetAsync(string Id)
        {
            var filter = Builders<Specialization>.Filter.Eq(x => x.Id, Id);
            return await _context.Specializations.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Specialization entity)
        {
            var filter = Builders<Specialization>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<Specialization>.Update
                .Set(x => x.Name, entity.Name)
                .Set(x => x.IsActive, entity.IsActive)
                .Set(x => x.DenyConsult, entity.DenyConsult);
            var result = await _context.Specializations.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
