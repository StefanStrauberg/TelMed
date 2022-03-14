using MediatR;
using Microsoft.Extensions.Logging;
using ReferralRequests.Application.Contracts.Persistence;
using ReferralRequests.Application.Exceptions;
using ReferralRequests.Application.Features.ReferralRequest.Requests.Commands;

namespace ReferralRequests.Application.Features.ReferralRequest.Handlers.Commands
{
    public class DeleteReferralRequestCommandHandler : IRequestHandler<DeleteReferralRequestCommand>
    {
        private readonly IReferralRequestRepository _repository;
        private readonly ILogger<DeleteReferralRequestCommandHandler> _logger;
        public DeleteReferralRequestCommandHandler(
            IReferralRequestRepository repository,
            ILogger<DeleteReferralRequestCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteReferralRequestCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"ReferralRequest {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
