using ImagingStudies.Domain;
using ImagingStudies.Infrastructure.Persistence.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ImagingStudies.Infrastructure.Persistence
{
    public class ImagingStudyContext : IImagingStudyContext
    {
        public IMongoCollection<ImagingStudy> ImagingStudies { get; }
        public ImagingStudyContext(IOptions<DatabaseSettings> dbOptions)
        {
            var Client = new MongoClient(dbOptions.Value.ConnectionString);
            var Databse = Client.GetDatabase(dbOptions.Value.DatabaseName);
            ImagingStudies = Databse.GetCollection<ImagingStudy>(dbOptions.Value.CollectionName);
        }
    }
}
