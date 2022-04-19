using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationDetailRequest(string Id) : IRequest<Domain.Organization>;
}
