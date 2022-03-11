using Organizations.Domain;

namespace Organizations.Application.DTO
{
    public class OrganizationDto
    {
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; } = true;
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; }
    }
}
