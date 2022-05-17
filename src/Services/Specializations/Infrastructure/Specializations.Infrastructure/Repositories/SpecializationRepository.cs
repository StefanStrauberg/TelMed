using MongoDB.Bson;
using MongoDB.Driver;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Specs;
using Specializations.Domain;
using Specializations.Infrastructure.Persistence;

namespace Specializations.Infrastructure.Repositories
{
    public class SpecializationRepository : ISpecializationRepository, IDisposable
    {
        private readonly ISpecializationContext _context;
        public SpecializationRepository(ISpecializationContext context)
            => _context = context;

        public async Task<long> CountAsync(QuerySpecParams querySpecParams)
            => await _context.Specializations
                .Find(GetFilter(querySpecParams.Search))
                .CountDocumentsAsync();

        public async Task CreateAsync(Specialization entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Specializations.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Specializations
                .DeleteOneAsync(Builders<Specialization>.Filter.Eq(x => x.Id, id));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync(QuerySpecParams querySpecParams)
            => await _context.Specializations.Find(GetFilter(querySpecParams.Search))
                .Skip((querySpecParams.PageIndex - 1) * querySpecParams.PageSize)
                .Limit(querySpecParams.PageSize)
                .Sort(GetSort(querySpecParams.Sort))
                .ToListAsync();

        public async Task<Specialization> GetAsync(string id)
            => await _context.Specializations
                .Find(Builders<Specialization>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(Specialization entity, string id)
        {
            var result = await _context.Specializations
                .UpdateOneAsync(
                Builders<Specialization>.Filter.Eq(x => x.Id, id),
                Builders<Specialization>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Name, entity.Name)
                .Set(x => x.IsActive, entity.IsActive)
                .Set(x => x.DenyConsult, entity.DenyConsult));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private FilterDefinition<Specialization> GetFilter(string search) =>
            search switch 
            {
                null => FilterDefinition<Specialization>.Empty,
                _ => Builders<Specialization>.Filter
                    .Regex(x => x.Name, new BsonRegularExpression(search, "i"))
            };

        private SortDefinition<Specialization> GetSort(string sort) =>
            sort switch
            {
                "OrderByDescending" => Builders<Specialization>.Sort.Descending(x => x.Name),
                _ => Builders<Specialization>.Sort.Ascending(x => x.Name)
            };

        public async Task<object> GetShortSpecializaitons()
            => await _context.Specializations.Find(x => true)
                .Project(x => new { Id = x.Id, Name = x.Name})
                .ToListAsync();
    }
}
