using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Application.Errors;
using Organizations.Application.GrpcServices;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationDetailRequestHandler : IRequestHandler<GetOrganizationDetailRequest, OrganizationDto>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly SpecializationGrpcService _specializationGrpcService;
        public GetOrganizationDetailRequestHandler(
            IOrganizationRepository repository,
            IMapper mapper,
            SpecializationGrpcService specializationGrpcService)
        {
            _repository = repository;
            _mapper = mapper;
            _specializationGrpcService = specializationGrpcService;
        }
        public async Task<OrganizationDto> Handle(GetOrganizationDetailRequest request, 
            CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAsync(request.id);
            if (organization is null)
                throw new OrganizationBadRequestException(request.id);
            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
