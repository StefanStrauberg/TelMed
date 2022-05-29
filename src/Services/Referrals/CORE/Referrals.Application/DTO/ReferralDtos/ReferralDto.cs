using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;
using Referrals.Domain.ReferralEntity;

namespace Referrals.Application.DTO.ReferralDtos
{
    public class ReferralDto
    {
        public string Id { get; set; }
        public ReferralStatus Status { get; set; }
        public Patient Patient { get; set; }
        public string AuthorId { get; set; }
        public List<Anamnesis> Anamnesis { get; set; }
        public List<string> ImagingStudies { get; set; }
        public List<string> Observations { get; set; }
        public List<Purpose> Purpose { get; set; }
        public MedicalAttention MedicalAttention { get; set; }
        public string RecallCause { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
    }
}
