using AutoMapper;
using Grpc.Core;
using Organization.GRPC.Repositories;

namespace Organization.GRPC.Services
{
    public class OrganizationService : OrganizationProtoService.OrganizationProtoServiceBase
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        public OrganizationService(
            IOrganizationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public override async Task<OrgName> GetOrgNameById(GetOrgIdRequest request, ServerCallContext context)
            => new OrgName { Name = await _repository.GetUsualNameAsync(request.Id) };

        public override async Task<OrgNameList> GetOrgNameByIds(GetOrgIdsRequestList request, ServerCallContext context)
        {
            var result = await _repository.GetOrgNamesByIds(_mapper.Map<List<string>>(request.Id));
            return _mapper.Map<OrgNameList>(result);
        }
    }
}
