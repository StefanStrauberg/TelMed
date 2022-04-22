using MediatR;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public record DeleteObservationCommand(string id) : IRequest;
}
