using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Exceptions;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.Application.Features.Organization.Handlers.Queries
{
    public class GetOrganizationDetailRequestHandler : IRequestHandler<GetOrganizationDetailRequest, Domain.Organization>
    {
        private readonly IOrganizationRepository _repository;
        public GetOrganizationDetailRequestHandler(
            IOrganizationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Organization> Handle(GetOrganizationDetailRequest request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAsync(request.Id);
            if (organization is null)
                throw new NotFoundException(nameof(request), request.Id);
            return organization;
        }
    }
}
