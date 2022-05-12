using Organization.GRPC.Entities.Common;

namespace Organization.GRPC.Entities
{
    public class Organization : BaseDomainEntity
    {
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        public OrganizationName OrganizationName { get; set; }
        public List<string> SpecializationIds { get; set; }
    }
}
