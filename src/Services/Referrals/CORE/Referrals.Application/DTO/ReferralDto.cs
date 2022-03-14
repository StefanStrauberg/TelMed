using Referrals.Domain;

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
        public List<string> Anamnesis { get; set; }
        public List<string> ImagingStudies { get; set; }
        public List<string> Observations { get; set; }
        public List<string> PurposeList { get; set; }
        public MedicalAttention MedicalAttention { get; set; }
        public string RecallCause { get; set; }
    }
}
