using MediatR;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public class GetOrganizationDetailRequest : IRequest<Domain.Organization>
    {
        public string Id { get; set; }
    }
}
