using MongoDB.Bson;
using MongoDB.Driver;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Specs;
using Organizations.Domain;
using Organizations.Infrastructure.Persistence;

namespace Organizations.Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository, IDisposable
    {
        private readonly IOrganizationContext _context;
        public OrganizationRepository(IOrganizationContext context)
            => _context = context;

        public async Task<long> CountAsync(QuerySpecParams querySpecParams)
            => await _context.Organizations
                .Find(GetFilter(querySpecParams.Search))
                .CountDocumentsAsync();

        public async Task CreateAsync(Organization entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Organizations.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _context.Organizations
                .DeleteOneAsync(Builders<Organization>.Filter.Eq(x => x.Id, id));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IReadOnlyList<Organization>> GetAllAsync(QuerySpecParams querySpecParams)
            => await _context.Organizations.Find(GetFilter(querySpecParams.Search))
                .Skip((querySpecParams.PageIndex) * querySpecParams.PageSize)
                .Limit(querySpecParams.PageSize)
                .Sort(GetSort(querySpecParams.Sort))
                .ToListAsync();

        public async Task<Organization> GetAsync(string id)
            => await _context.Organizations.
                Find(Builders<Organization>.Filter.Eq(x => x.Id, id))
                .FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(Organization entity, string id)
        {
            var result = await _context.Organizations
                .UpdateOneAsync(
                Builders<Organization>.Filter.Eq(x => x.Id, id),
                Builders<Organization>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.Level, entity.Level)
                .Set(x => x.Region, entity.Region)
                .Set(x => x.Address, entity.Address)
                .Set(x => x.IsActive, entity.IsActive)
                .Set(x => x.OrganizationName, entity.OrganizationName)
                .Set(x => x.SpecializationIds, entity.SpecializationIds));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private FilterDefinition<Organization> GetFilter(string search) =>
            search switch 
            {
                null => FilterDefinition<Organization>.Empty,
                _ => Builders<Organization>.Filter
                    .Regex(x => x.OrganizationName.OfficialName, new BsonRegularExpression(search, "i"))
            };

        private SortDefinition<Organization> GetSort(string sort) =>
            sort switch
            {
                "OrderByDescending" => Builders<Organization>.Sort.Descending(x => x.OrganizationName.OfficialName),
                _ => Builders<Organization>.Sort.Ascending(x => x.OrganizationName.OfficialName)
            };

        public async Task<object> GetShortOrganizationsAsync()
        => await _context.Organizations.Find(x => true)
                .Project(x => new {
                    id = x.Id,
                    name = x.OrganizationName.OfficialName
                })
                .ToListAsync();
    }
}