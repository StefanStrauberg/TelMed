using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationListRequest : IRequest<IReadOnlyList<OrganizationDto>>;
}
