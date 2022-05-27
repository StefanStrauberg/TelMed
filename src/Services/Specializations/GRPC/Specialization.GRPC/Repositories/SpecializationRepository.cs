using MongoDB.Driver;
using Specializations.Infrastructure.Persistence;

namespace Specialization.GRPC.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly ISpecializationContext _context;
        public SpecializationRepository(ISpecializationContext context)
            => _context = context;

        public async Task<string> GetAsync(string Id)
            => await _context.Specializations
                .Find(Builders<Specializations.Domain.Specialization>.Filter.Eq(x => x.Id, Id))
                .Project(x => x.Name)
                .FirstOrDefaultAsync();

        public async Task<List<string>> GetSpecNamesByIds(List<string> ids)
            => await _context.Specializations
                .Find(Builders<Specializations.Domain.Specialization>.Filter.In(x => x.Id, ids))
                .Project(x => x.Name)
                .ToListAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
