using Organizations.Domain;

namespace Organizations.Application.DTO
{
    public class CreateOrganizationDto
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public string Address { get; set; }
        public string UsualName { get; set; }
        public string OfficialName { get; set; }
    }
}
