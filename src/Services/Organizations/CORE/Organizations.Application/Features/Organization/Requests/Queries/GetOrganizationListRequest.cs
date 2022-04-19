using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationListRequest : IRequest<IReadOnlyList<Domain.Organization>>;
}
