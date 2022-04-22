using MediatR;
using Observations.Application.DTO;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public record GetObservationDetailRequest(string id) : IRequest<ObservationDto>;
}
