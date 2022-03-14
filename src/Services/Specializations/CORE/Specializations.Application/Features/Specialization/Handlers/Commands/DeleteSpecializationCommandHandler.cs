using MediatR;
using Microsoft.Extensions.Logging;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Exceptions;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        private readonly ILogger<DeleteSpecializationCommandHandler> _logger;
        public DeleteSpecializationCommandHandler(
            ISpecializationRepository repository,
            ILogger<DeleteSpecializationCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            if(!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Specialization {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
