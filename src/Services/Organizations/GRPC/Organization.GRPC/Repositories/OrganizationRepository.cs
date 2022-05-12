﻿using MongoDB.Driver;
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

        public async Task<List<string>> GetOrgNamesByIds(List<string> ids)
            => await _context.Organizations
                .Find(Builders<Entities.Organization>.Filter.In(x => x.Id, ids))
                .Project(x => x.OrganizationName.UsualName)
                .ToListAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
