using MongoDB.Driver;
using Observations.Domain;

namespace Observations.Infrastructure.Persistence
{
    public interface IObservationContext
    {
        IMongoCollection<Observation> Observations { get; }
    }
}
