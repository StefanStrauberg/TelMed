using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationListRequestHandler : IRequestHandler<GetOrganizationListRequest, IReadOnlyList<Domain.Organization>>
    {
        private readonly IOrganizationRepository _repository;
        public GetOrganizationListRequestHandler(
            IOrganizationRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<Domain.Organization>> Handle(GetOrganizationListRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
