using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTOs.Organization;
using Organizations.Application.Exceptions;
using Organizations.Application.Features.Organization.Requests.Queries;

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
        public async Task<OrganizationDto> Handle(GetOrganizationDetailRequest request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAsync(request.Id);
            if (organization == default)
                throw new NotFoundException(nameof(request), request.Id);
            return _mapper.Map<OrganizationDto>(organization);
        }
    }
}
