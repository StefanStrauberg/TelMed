using MongoDB.Driver;
using Specialization.GRPC.DbContexts;

namespace Specialization.GRPC.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly IMongoSpecContext _context;
        public SpecializationRepository(IMongoSpecContext context)
            => _context = context;

        public async Task<string> GetAsync(string Id)
            => await _context.Specializations
                .Find(Builders<Entities.Specialization>.Filter.Eq(x => x.Id, Id))
                .Project(x => x.Name)
                .FirstOrDefaultAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
