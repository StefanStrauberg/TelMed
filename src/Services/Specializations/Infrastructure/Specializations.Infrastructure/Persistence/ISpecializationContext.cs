using MongoDB.Driver;
using Specializations.Domain;

namespace Specializations.Infrastructure.Persistence
{
    public interface ISpecializationContext
    {
        IMongoCollection<Specialization> Specializations { get; }
    }
}
