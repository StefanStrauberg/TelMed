
using Specialization.GRPC;

namespace Organizations.Application.GrpcServices
{
    public class SpecializationGrpcService
    {
        private readonly SpecializationProtoService.SpecializationProtoServiceClient _specializationServiceClient;
        public SpecializationGrpcService(SpecializationProtoService.SpecializationProtoServiceClient specializationServiceClient)
            => _specializationServiceClient = specializationServiceClient;
        public Task<string> GetSpecName(string id)
            => Task.FromResult(_specializationServiceClient.GetSpecNameAsync(new GetSpecRequest { Id = id }).GetAwaiter().GetResult().Name);
    }
}
