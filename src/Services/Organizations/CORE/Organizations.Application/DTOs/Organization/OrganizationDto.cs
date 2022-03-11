using Organizations.Application.DTOs.Common;
using Organizations.Domain;

namespace Organizations.Application.DTOs.Organization
{
    public class OrganizationDto : BaseDto
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; }
    }
}
