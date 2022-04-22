using MediatR;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Domain.Exceptions;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class DeleteObservationCommandHandler : IRequestHandler<DeleteObservationCommand>
    {
        private readonly IObservationsRepository _repository;
        public DeleteObservationCommandHandler(IObservationsRepository repository)
            => _repository = repository;
        public async Task<Unit> Handle(DeleteObservationCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.DeleteAsync(request.id))
                return Unit.Value;
            throw new ObservationBadRequestException(request.id);
        }
    }
}
