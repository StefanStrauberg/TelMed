using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Application.GrpcServices;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, IReadOnlyList<OrganizationDto>>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly SpecializationGrpcService _specializationGrpcService;
        public GetOrganizationListRequestHandler(
            IOrganizationRepository repository,
            IMapper mapper,
            SpecializationGrpcService specializationGrpcService)
        {
            _repository = repository;
            _mapper = mapper;
            _specializationGrpcService = specializationGrpcService;
        }
        public async Task<IReadOnlyList<OrganizationDto>> Handle(GetOrganizationListRequest request,
            CancellationToken cancellationToken) 
        {
            var organizations = await _repository.GetAllAsync(request.querySpecParams);
            foreach (var org in organizations)
            {
                if(org.SpecializationIds.Count() == 0)
                    continue;
                List<string> specNames = new List<string>();
                foreach (var id in org.SpecializationIds)
                {
                    specNames.Add(await _specializationGrpcService.GetSpecName(id));
                }
                org.SpecializationIds = specNames;
            }
            return _mapper.Map<IReadOnlyList<OrganizationDto>>(organizations);
        }
    }
}
