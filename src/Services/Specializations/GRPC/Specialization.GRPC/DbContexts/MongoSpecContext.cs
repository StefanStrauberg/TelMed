using MongoDB.Driver;

namespace Specialization.GRPC.DbContexts
{
    public class MongoSpecContext : IMongoSpecContext
    {
        private readonly IConfiguration _configuration;
        public IMongoCollection<Specialization.GRPC.Entities.Specialization> Specializations { get; }
        public MongoSpecContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var Client = new MongoClient(_configuration["SpecializationDbSettings:ConnectionString"]);
            var Databse = Client.GetDatabase(_configuration["SpecializationDbSettings:DatabaseName"]);
            Specializations = Databse.GetCollection<Specialization.GRPC.Entities.Specialization>
                (_configuration["SpecializationDbSettings:CollectionName"]);
        }
    }
}
