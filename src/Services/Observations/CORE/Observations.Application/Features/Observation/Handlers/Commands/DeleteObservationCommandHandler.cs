using MediatR;
using Microsoft.Extensions.Logging;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Exceptions;
using Observations.Application.Features.Observation.Requests.Commands;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class DeleteObservationCommandHandler : IRequestHandler<DeleteObservationCommand>
    {
        private readonly IObservationsRepository _repository;
        private readonly ILogger<DeleteObservationCommandHandler> _logger;
        public DeleteObservationCommandHandler(
            IObservationsRepository repository,
            ILogger<DeleteObservationCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteObservationCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Observation {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
