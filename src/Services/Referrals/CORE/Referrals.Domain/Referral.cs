using BaseDomain;

namespace Referrals.Domain
{
    /// <summary>
    /// Patient consultation
    /// </summary>
    public class Referral : BaseDomainEntity
    {
        public ReferralStatus Status { get; set; } = ReferralStatus.Incomplete;
        public Patient Patient { get; set; }
        public Guid AuthorId { get; set; }
        public List<string> Anamnesis { get; set; } = new List<string>();
        public List<string> ImagingStudies { get; set; } = new List<string>();
        public List<string> Observations { get; set; } = new List<string>();
        public List<string> PurposeList { get; set; } = new List<string>();
        public MedicalAttention MedicalAttention { get; set; } = MedicalAttention.Planned;
        public string RecallCause { get; set; }
    }
}
