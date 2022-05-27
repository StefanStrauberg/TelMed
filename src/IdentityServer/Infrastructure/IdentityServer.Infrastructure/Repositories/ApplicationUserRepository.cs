using BaseDomain.Specs;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Domain;
using IdentityServer.Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IdentityServer.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IIdentityContext _context;
        public ApplicationUserRepository(IIdentityContext context)
            => _context = context;
        public async Task<List<ApplicationUser>> GetAllAsync(QuerySpecParams querySpecParams)
            => await _context.Accounts.Find(GetFilter(querySpecParams.Search))
                    .Skip((querySpecParams.PageIndex) * querySpecParams.PageSize)
                    .Limit(querySpecParams.PageSize)
                    .Sort(GetSort(querySpecParams.Sort))
                    .ToListAsync();

        public async Task<ApplicationUser> GetAsync(Guid Id)
            => await _context.Accounts
                .Find(Builders<ApplicationUser>.Filter.Eq(x => x.Id, Id))
                .FirstOrDefaultAsync();

        private FilterDefinition<ApplicationUser> GetFilter(string search) =>
            search switch
            {
                null => FilterDefinition<ApplicationUser>.Empty,
                _ => Builders<ApplicationUser>.Filter
                    .Regex(x => x.UserName, new BsonRegularExpression(search, "i"))
            };

        private SortDefinition<ApplicationUser> GetSort(string sort) =>
            sort switch
            {
                "OrderByDescending" => Builders<ApplicationUser>.Sort.Descending(x => x.UserName),
                _ => Builders<ApplicationUser>.Sort.Ascending(x => x.UserName)
            };

        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task<long> CountAsync(QuerySpecParams querySpecParams)
            => await _context.Accounts
                .Find(GetFilter(querySpecParams.Search))
                .CountDocumentsAsync();
    }
}
