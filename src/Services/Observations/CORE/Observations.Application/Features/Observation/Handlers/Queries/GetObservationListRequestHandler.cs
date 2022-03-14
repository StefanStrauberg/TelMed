using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Queries;

namespace Observations.Application.Features.Observation.Handlers.Queries
{
    public class GetObservationListRequestHandler : IRequestHandler<GetObservationListRequest, IReadOnlyList<Domain.Observation>>
    {
        private readonly IObservationsRepository _repository;
        public GetObservationListRequestHandler(
            IObservationsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<Domain.Observation>> Handle(GetObservationListRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
