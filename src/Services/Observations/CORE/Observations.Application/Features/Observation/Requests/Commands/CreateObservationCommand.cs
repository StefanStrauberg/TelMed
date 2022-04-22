using MediatR;
using Observations.Application.DTO;

namespace Observations.Application.Features.Observation.Requests.Commands
{
    public record CreateObservationCommand(CreateObservationDto model) : IRequest;
}
