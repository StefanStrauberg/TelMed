using Referrals.Domain;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.ImagingStudyEntity;
using Referrals.Domain.ObservationEntity;
using Referrals.Domain.PatientEntity;
using Referrals.Domain.PurposeEntity;

namespace Referrals.Application.DTO
{
    public class ReferralDto
    {
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
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
