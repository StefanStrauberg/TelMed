using ImagingStudies.Domain;
using MongoDB.Driver;

namespace ImagingStudies.Infrastructure.Persistence
{
    public interface IImagingStudyContext
    {
        IMongoCollection<ImagingStudy> ImagingStudies { get; }
    }
}
