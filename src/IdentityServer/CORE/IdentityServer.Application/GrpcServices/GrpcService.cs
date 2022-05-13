using AutoMapper;
using Organization.GRPC;
using Specialization.GRPC;

namespace IdentityServer.Application.GrpcServices
{
    public class GrpcService : IGrpcService
    {
        private readonly SpecializationProtoService.SpecializationProtoServiceClient _specializationServiceClient;
        private readonly OrganizationProtoService.OrganizationProtoServiceClient _organizationServiceClient;
        private readonly IMapper _mapper;
        public GrpcService(
            SpecializationProtoService.SpecializationProtoServiceClient specializationServiceClient,
            IMapper mapper,
            OrganizationProtoService.OrganizationProtoServiceClient organizationServiceClient)
        {
            _specializationServiceClient = specializationServiceClient;
            _mapper = mapper;
            _organizationServiceClient = organizationServiceClient;
        }

        public async Task<string> GetOrgName(string id)
            => _mapper.Map<string>(
                    await _organizationServiceClient.GetOrgNameByIdAsync(new GetOrgIdRequest { Id = id }));

        public async Task<List<string>> GetOrgNamesByListIds(List<string> ids)
            => _mapper.Map<List<string>>(
                    await _organizationServiceClient.GetOrgNamesByIdsAsync(_mapper.Map<GetOrgIdsRequestList>(ids)));

        public async Task<string> GetSpecName(string id)
            => _mapper.Map<string>(
                    await _specializationServiceClient.GetSpecNameByIdAsync(new GetSpecIdRequest { Id = id }));

        public async Task<List<string>> GetSpecNamesByListIds(List<string> ids)
            => _mapper.Map<List<string>>(
                    await _specializationServiceClient.GetSpecNamesByIdsAsync(_mapper.Map<GetSpecIdsRequestList>(ids)));
    }
}
