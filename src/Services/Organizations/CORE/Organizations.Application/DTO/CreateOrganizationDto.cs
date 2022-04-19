using Organizations.Domain;

namespace Organizations.Application.DTO
{
    public class CreateOrganizationDto
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public OrganizationName OrganizationName { get; set; }
    }
}
