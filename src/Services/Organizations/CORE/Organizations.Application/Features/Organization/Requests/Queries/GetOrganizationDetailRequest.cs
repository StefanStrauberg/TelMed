using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationDetailRequest(string Id) : IRequest<OrganizationDto>;
}
