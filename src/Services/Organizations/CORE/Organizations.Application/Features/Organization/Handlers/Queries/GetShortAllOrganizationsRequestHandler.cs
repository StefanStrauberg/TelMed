using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetShortAllOrganizationsRequestHandler : IRequestHandler<GetShortAllOrganizationsRequest, Object>
    {
        private readonly IOrganizationRepository _repository;
        public GetShortAllOrganizationsRequestHandler(IOrganizationRepository repository)
            => _repository = repository;
        public async Task<object> Handle(GetShortAllOrganizationsRequest request, CancellationToken cancellationToken)
            => await _repository.GetShortOrganizationsAsync();
    }
}