using Observations.Domain;

namespace Observations.Application.DTO
{
    public class CreateObservationDto
    {
        public string ReferralId { get; set; }
        public DateTime ObservationDate { get; set; }
        public string Description { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}