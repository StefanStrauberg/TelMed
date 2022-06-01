using Organizations.Domain;

namespace Organizations.Application.DTO
{
    public class OrganizationDto
    {
        public string Id { get; set; }
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string UsualName { get; set; }
        public string OfficialName { get; set; }
        public string SpecializationIds { get; set; }
    }
}
