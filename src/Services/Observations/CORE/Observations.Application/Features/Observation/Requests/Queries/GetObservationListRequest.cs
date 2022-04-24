using MediatR;
using Observations.Application.DTO;
using Observations.Application.Specs;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public record GetObservationListRequest(QuerySpecParams querySpecParams) : IRequest<IReadOnlyList<ObservationDto>>;
}
