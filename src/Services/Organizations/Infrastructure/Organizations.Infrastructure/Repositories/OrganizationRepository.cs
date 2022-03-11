using MongoDB.Driver;
using Organizations.Application.Contracts.Persistence;
using Organizations.Domain;
using Organizations.Infrastructure.Persistence;

namespace Organizations.Infrastructure.Repositories
{
    public class OrganizationRepository : IOrganizationRepository, IDisposable
    {
        private readonly IOrganizationContext _context;
        public OrganizationRepository(IOrganizationContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(Organization entity)
        {
            await _context.Organizations.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Organization>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Organizations.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }


        public async Task<IReadOnlyList<Organization>> GetAllAsync()
        {
            return await _context.Organizations.Find(x => true).ToListAsync();
        }

        public async Task<Organization> GetAsync(string Id)
        {
            var filter = Builders<Organization>.Filter.Eq(x => x.Id, Id);
            return await _context.Organizations.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Organization entity)
        {
            var filter = Builders<Organization>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<Organization>.Update
                .Set(x => x.Level, entity.Level)
                .Set(x => x.Region, entity.Region)
                .Set(x => x.Address, entity.Address)
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.OrganizationName, entity.OrganizationName)
                .Set(x => x.SpecializationIds, entity.SpecializationIds);
            var result = await _context.Organizations.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
