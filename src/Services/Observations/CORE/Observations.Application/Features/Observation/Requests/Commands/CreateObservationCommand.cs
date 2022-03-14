using MediatR;
using Observations.Domain;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public class CreateObservationCommand : IRequest<string>
    {
        public string ReferralId { get; set; }
        public string Description { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
