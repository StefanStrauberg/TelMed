using MongoDB.Driver;
using Organization.GRPC.DbContexts;

namespace Organization.GRPC.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IMongoOrgContext _context;
        public OrganizationRepository(IMongoOrgContext context)
            => _context = context;

        public async Task<string> GetUsualNameAsync(string Id)
            => await _context.Organizations
                .Find(Builders<Entities.Organization>.Filter.Eq(x => x.Id, Id))
                .Project(x => x.OrganizationName.UsualName)
                .FirstOrDefaultAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
