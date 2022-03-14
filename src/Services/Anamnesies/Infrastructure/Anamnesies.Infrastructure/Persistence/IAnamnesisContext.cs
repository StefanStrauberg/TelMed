using Anamnesies.Domain;
using MongoDB.Driver;

namespace Anamnesies.Infrastructure.Persistence
{
    public interface IAnamnesisContext
    {
        IMongoCollection<Anamnesis> Anamnesies { get; }
    }
}
