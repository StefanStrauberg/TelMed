using MediatR;
using Observations.Application.DTO;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public record UpdateObservationCommand(UpdateObservationDto model, string id) : IRequest;
}
