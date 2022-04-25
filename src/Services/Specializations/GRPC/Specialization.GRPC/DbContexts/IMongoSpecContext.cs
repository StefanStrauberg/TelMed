using MongoDB.Driver;

namespace Specialization.GRPC.DbContexts
{
    public interface IMongoSpecContext
    {
        IMongoCollection<Specialization.GRPC.Entities.Specialization> Specializations { get; }
    }
}
