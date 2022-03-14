using MediatR;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public class DeleteObservationCommand : IRequest
    {
        public string Id { get; set; }
    }
}
