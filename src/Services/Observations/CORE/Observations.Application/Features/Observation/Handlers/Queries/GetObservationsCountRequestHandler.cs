using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Queries;

namespace Observations.Application.Features.Observation.Handlers.Queries
{
    public class GetObservationsCountRequestHandler : IRequestHandler<GetObservationsCountRequest, long>
    {
        private readonly IObservationsRepository _repository;
        public GetObservationsCountRequestHandler(IObservationsRepository repository)
            => _repository = repository;
        public async Task<long> Handle(GetObservationsCountRequest request, CancellationToken cancellationToken)
            => await _repository.CountAsync(request.querySpecParams);
    }
}