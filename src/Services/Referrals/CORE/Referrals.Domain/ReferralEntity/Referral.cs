using BaseDomain;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;

namespace Referrals.Domain.ReferralEntity
{
    /// <summary>
    /// Patient consultation
    /// </summary>
    public class Referral : BaseDomainEntity
    {
        public ReferralStatus Status { get; set; } = ReferralStatus.Incomplete;
        public Patient Patient { get; set; }
        public Guid AuthorId { get; set; }
        public List<Anamnesis> Anamnesis { get; set; } = new List<Anamnesis>();
        public List<string> ImagingStudies { get; set; } = new List<string>();
        public List<string> Observations { get; set; } = new List<string>();
        public List<Purpose> PurposeList { get; set; } = new List<Purpose>();
        public MedicalAttention MedicalAttention { get; set; } = MedicalAttention.Planned;
        public string RecallCause { get; set; }
    }
}
