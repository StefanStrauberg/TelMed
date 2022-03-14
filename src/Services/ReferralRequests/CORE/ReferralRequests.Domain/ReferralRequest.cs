using ReferralRequests.Domain.Common;

namespace ReferralRequests.Domain
{
    public class ReferralRequest : BaseDomainEntity
    {
        public List<string> ReferralResponses { get; set; } = new List<string>();
        public string Diagnosis { get; set; }
        public string ReferralId { get; private set; }
        public string SpecializationId { get; private set; }
        public string OrganizationId { get; private set; }
        public Guid AccountId { get; private set; }
    }
}
