using BaseDomain;

namespace Referrals.Domain.PurposeEntity
{
    public abstract class Purpose : BaseDomainEntity
    {
        public PurposeGroup Group { get; set; }
        public string Resume { get; set; }
    }
}
