using MongoDB.Driver;
using Purposes.Domain;

namespace Purposes.Infrastructure.Persistence
{
    public interface IPurposeContext
    {
        IMongoCollection<Purpose> Purposes { get; }
    }
}
