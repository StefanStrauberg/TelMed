using Organizations.Domain;

namespace Organizations.Application.DTOs.Organization
{
    public class CreateOrganizationDto : IOrganizationDto
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; }
    }
}
