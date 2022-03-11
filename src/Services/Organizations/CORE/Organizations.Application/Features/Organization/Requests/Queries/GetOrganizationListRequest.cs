using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public class GetOrganizationListRequest : IRequest<IReadOnlyList<OrganizationDto>>
    {
    }
}
