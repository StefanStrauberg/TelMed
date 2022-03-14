using MediatR;
using Observations.Domain;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public class UpdateObservationCommand : IRequest
    {
        public string Id { get; set; }
        public string ReferralId { get; set; }
        public DateTime ObservationDate { get; set; }
        public string Description { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
