using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Errors;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationDetailRequestHandler : IRequestHandler<GetOrganizationDetailRequest, OrganizationDetailDto>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        public GetOrganizationDetailRequestHandler(
            IOrganizationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<OrganizationDetailDto> Handle(GetOrganizationDetailRequest request, 
            CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAsync(request.id);
            if (organization is null)
                throw new OrganizationBadRequestException(request.id);
            return _mapper.Map<OrganizationDetailDto>(organization);
        }
    }
}
