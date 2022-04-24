using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationsCountRequestHandler : IRequestHandler<GetOrganizationsCountRequest, long>
    {
        private readonly IOrganizationRepository _repository;
        public GetOrganizationsCountRequestHandler(IOrganizationRepository repository) 
            => _repository = repository;
        public Task<long> Handle(GetOrganizationsCountRequest request, CancellationToken cancellationToken)
            => _repository.CountAsync(request.querySpecParams);
    }
}