﻿using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Domain;
using Anamnesies.Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Referrals.Infrastructure.Repositories
{
    public class AnamnesisRepository : IAnamnesisRepository, IDisposable
    {
        private readonly IAnamnesisContext _context;
        public AnamnesisRepository(IAnamnesisContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAsync(Anamnesis entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await _context.Anamnesies.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            var filter = Builders<Anamnesis>.Filter.Eq(x => x.Id, Id);
            var result = await _context.Anamnesies.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IReadOnlyList<Anamnesis>> GetAllAsync()
        {
            return await _context.Anamnesies.Find(x => true).ToListAsync();
        }

        public async Task<Anamnesis> GetAsync(string Id)
        {
            var filter = Builders<Anamnesis>.Filter.Eq(x => x.Id, Id);
            return await _context.Anamnesies.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Anamnesis>> GetAllAsyncByRefferalId(string id)
        {
            return await _context.Anamnesies.Find(x => x.ReferralId == id).ToListAsync();
        }

        public async Task<string> GetReferralId(string id)
        {
            var filter = Builders<Anamnesis>.Filter.Eq(x => x.Id, id);
            return await _context.Anamnesies.Find(filter)
                .Project(x => x.ReferralId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Anamnesis entity, string Id)
        {
            var filter = Builders<Anamnesis>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Anamnesis>.Update
                .Set(x => x.Updated, DateTime.Now)
                .Set(x => x.CategoryId, entity.CategoryId)
                .Set(x => x.Summary, entity.Summary);
            var result = await _context.Anamnesies.UpdateOneAsync(filter, update);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> ContainsAnamnesisCategoryAsync(AnamnesisCategory CategoryId, string ReferralId)
        {
            var filter = Builders<Anamnesis>.Filter.Eq(x => x.ReferralId, ReferralId);
            var document = await _context.Anamnesies.Find(filter).ToListAsync();
            return document.Exists(x => x.CategoryId == CategoryId);
        }
    }
}
