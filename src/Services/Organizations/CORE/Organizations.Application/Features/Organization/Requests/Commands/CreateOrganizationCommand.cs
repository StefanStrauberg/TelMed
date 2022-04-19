using MediatR;
using Organizations.Domain;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public record CreateOrganizationCommand : IRequest
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public OrganizationName OrganizationName { get; set; }
    }
}
