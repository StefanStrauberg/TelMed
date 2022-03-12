using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.Common;
using Referrals.Domain.ImagingStudyEntity;
using Referrals.Domain.ObservationEntity;
using Referrals.Domain.PatientEntity;
using Referrals.Domain.PurposeEntity;

namespace Referrals.Domain
{
    /// <summary>
    /// Patient consultation
    /// </summary>
    public class Referral : BaseDomainEntity
    {
        public ReferralStatus Status { get; set; }
        public Patient Patient { get; set; }
        public Guid AuthorId { get; set; }
        public List<Anamnesis> Anamnesis { get; set; }
        public List<ImagingStudy> ImagingStudies { get; set; }
        public List<Observation> Observations { get; set; }
        public List<Purpose> PurposeList { get; set; }
        public MedicalAttention MedicalAttention { get; set; }
        public string RecallCause { get; set; }
    }
}
