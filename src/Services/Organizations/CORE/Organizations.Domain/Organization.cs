using Organizations.Domain.Common;

namespace Organizations.Domain
{
    /// <summary>
    /// Class describing the organization
    /// </summary>
    public class Organization : BaseDomainEntity
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; } = true;
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; } = new List<string>();
    }
}
