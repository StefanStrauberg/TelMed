using BaseDomain;

namespace Purposes.Domain
{
    public abstract class Purpose : BaseDomainEntity
    {
        public string ReferralId { get; set; }
        public PurposeGroup Group { get; set; }
        public string Resume { get; set; }
    }
}
