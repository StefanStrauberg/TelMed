using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, IReadOnlyList<OrganizationDto>>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        public GetOrganizationListRequestHandler(
            IOrganizationRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<OrganizationDto>> Handle(GetOrganizationListRequest request,
            CancellationToken cancellationToken) 
            => _mapper.Map<IReadOnlyList<OrganizationDto>>(await _repository.GetAllAsync());
    }
}
