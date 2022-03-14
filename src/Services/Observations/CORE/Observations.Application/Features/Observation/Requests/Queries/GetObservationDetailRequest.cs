using MediatR;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public class GetObservationDetailRequest : IRequest<Domain.Observation>
    {
        public string Id { get; set; }
    }
}
