using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Domain;
using ImagingStudies.Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ImagingStudies.Infrastructure.Repositories
{
    public class ImagingStudyRepository : IImagingStudyRepository, IDisposable
    {
        private readonly IImagingStudyContext _context;
        public ImagingStudyRepository(IImagingStudyContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ImagingStudy entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.ImagingStudies.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<ImagingStudy>.Filter.Eq(x => x.Id, Id);
            var result = await _context.ImagingStudies.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<ImagingStudy>> GetAllAsync()
        {
            return await _context.ImagingStudies.Find(x => true).ToListAsync();
        }

        public async Task<ImagingStudy> GetAsync(string Id)
        {
            var filter = Builders<ImagingStudy>.Filter.Eq(x => x.Id, Id);
            return await _context.ImagingStudies.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(ImagingStudy entity)
        {
            var filter = Builders<ImagingStudy>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<ImagingStudy>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Uid, entity.Uid)
                .Set(x => x.Description, entity.Description);
            var result = await _context.ImagingStudies.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
