using MediatR;
using Organizations.Application.DTOs.Organization;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public class GetOrganizationListRequest : IRequest<IReadOnlyList<OrganizationDto>>
    {
    }
}
