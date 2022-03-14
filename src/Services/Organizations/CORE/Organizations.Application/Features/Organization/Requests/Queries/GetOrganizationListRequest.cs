using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public class GetOrganizationListRequest : IRequest<IReadOnlyList<Domain.Organization>>
    {
    }
}
