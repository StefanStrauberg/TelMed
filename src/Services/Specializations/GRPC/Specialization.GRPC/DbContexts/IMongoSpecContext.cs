using MongoDB.Driver;

namespace Specialization.GRPC.DbContexts
{
    public interface IMongoSpecContext
    {
        IMongoCollection<Entities.Specialization> Specializations { get; }
    }
}
