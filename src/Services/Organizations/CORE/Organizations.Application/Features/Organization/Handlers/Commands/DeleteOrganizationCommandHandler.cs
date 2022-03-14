using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Exceptions;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        private readonly ILogger<DeleteOrganizationCommandHandler> _logger;
        public DeleteOrganizationCommandHandler(
            IOrganizationRepository repository,
            ILogger<DeleteOrganizationCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            if(!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Organization {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
