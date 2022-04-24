using MediatR;
using Organizations.Application.DTO;
using Organizations.Application.Specs;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationListRequest(QuerySpecParams querySpecParams) : IRequest<IReadOnlyList<OrganizationDto>>;
}
