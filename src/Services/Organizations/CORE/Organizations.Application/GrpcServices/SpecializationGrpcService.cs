
using AutoMapper;
using Specialization.GRPC;

namespace Organizations.Application.GrpcServices
{
    public class SpecializationGrpcService
    {
        private readonly SpecializationProtoService.SpecializationProtoServiceClient _specializationServiceClient;
        private readonly IMapper _mapper;
        public SpecializationGrpcService(
            SpecializationProtoService.SpecializationProtoServiceClient specializationServiceClient,
            IMapper mapper)
        {
            _specializationServiceClient = specializationServiceClient;
            _mapper = mapper;
        }
        public Task<string> GetSpecName(string id)
            => Task.FromResult(_specializationServiceClient.GetSpecNameByIdAsync(new GetSpecIdRequest { Id = id }).GetAwaiter().GetResult().Name);

        public async Task<List<string>> GetSpecNamesByListIds(List<string> ids)
        {
            var request = _mapper.Map<GetSpecIdsRequestList>(ids);
            var result = await _specializationServiceClient.GetSpecNamesByIdsAsync(request);
            return _mapper.Map<List<string>>(result);
        }
    }
}
