using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Exceptions;
using Observations.Application.Features.Observation.Requests.Queries;

namespace Observations.Application.Features.Observation.Handlers.Queries
{
    public class GetObservationsDetailRequestHandler : IRequestHandler<GetObservationDetailRequest, Domain.Observation>
    {
        private readonly IObservationsRepository _repository;
        public GetObservationsDetailRequestHandler(
            IObservationsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Observation> Handle(GetObservationDetailRequest request, CancellationToken cancellationToken)
        {
            var obsevation = await _repository.GetAsync(request.Id);
            if (obsevation is null)
                throw new NotFoundException(nameof(request), request.Id);
            return obsevation;
        }
    }
}
