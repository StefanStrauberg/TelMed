using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Domain.Exceptions;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationDetailRequestHandler : IRequestHandler<GetOrganizationDetailRequest, OrganizationDto>
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
        public async Task<OrganizationDto> Handle(GetOrganizationDetailRequest request, 
            CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAsync(request.id);
            if (organization is null)
                throw new OrganizationNotFoundException(request.id);
            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
