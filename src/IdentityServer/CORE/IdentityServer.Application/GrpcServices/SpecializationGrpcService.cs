using Specialization.GRPC;

namespace IdentityServer.Application.GrpcServices
{
    public class SpecializationGrpcService
    {
        private readonly SpecializationProtoService.SpecializationProtoServiceClient _specializationServiceClient;
        public SpecializationGrpcService(SpecializationProtoService.SpecializationProtoServiceClient specializationServiceClient)
            => _specializationServiceClient = specializationServiceClient;
        public async Task<string> GetSpecName(string id)
        {
            var specName = await _specializationServiceClient.GetSpecNameAsync(new GetSpecRequest { Id = id });
            return specName.Name;
        }
    }
}
