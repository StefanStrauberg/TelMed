using AutoMapper;
using Specialization.GRPC;

namespace Organizations.Application.GrpcServices
{
    public class GrpcService : IGrpcService
    {
        private readonly SpecializationProtoService.SpecializationProtoServiceClient _specializationServiceClient;
        private readonly IMapper _mapper;
        public GrpcService(
            SpecializationProtoService.SpecializationProtoServiceClient specializationServiceClient,
            IMapper mapper)
        {
            _specializationServiceClient = specializationServiceClient;
            _mapper = mapper;
        }
        public async Task<string> GetSpecName(string id)
            => _mapper.Map<string>(
                    await _specializationServiceClient.GetSpecNameByIdAsync(new GetSpecIdRequest { Id = id }));

        public async Task<List<string>> GetSpecNamesByListIds(List<string> ids)
            => _mapper.Map<List<string>>(
                    await _specializationServiceClient.GetSpecNamesByIdsAsync(_mapper.Map<GetSpecIdsRequestList>(ids)));
    }
}
