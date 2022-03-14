using MediatR;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public class GetObservationListRequest : IRequest<IReadOnlyList<Domain.Observation>>
    {
    }
}
