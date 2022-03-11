using MediatR;
using Organizations.Application.DTO;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public class GetOrganizationDetailRequest : IRequest<OrganizationDto>
    {
        public string Id { get; set; }
    }
}
