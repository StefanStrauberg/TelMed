using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Exceptions;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class DeleteAnamnesisCommandHandler : IRequestHandler<DeleteAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly ILogger<DeleteAnamnesisCommandHandler> _logger;
        public DeleteAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            ILogger<DeleteAnamnesisCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteAnamnesisCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Anamnesis {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
