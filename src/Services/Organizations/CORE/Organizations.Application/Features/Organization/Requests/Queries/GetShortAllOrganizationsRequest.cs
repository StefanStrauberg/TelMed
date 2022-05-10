using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetShortAllOrganizationsRequest : IRequest<Object>;
}