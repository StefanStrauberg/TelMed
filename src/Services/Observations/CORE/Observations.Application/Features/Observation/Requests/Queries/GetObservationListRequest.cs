using MediatR;
using Observations.Application.DTO;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public record GetObservationListRequest : IRequest<IReadOnlyList<ObservationDto>>;
}
