using MediatR;
using Organizations.Domain;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public class UpdateOrganizationCommand : IRequest
    {
        public string Id { get; set; }
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; }
    }
}
