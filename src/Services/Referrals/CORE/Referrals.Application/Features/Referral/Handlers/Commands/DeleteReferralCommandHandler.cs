using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class DeleteReferralCommandHandler : IRequestHandler<DeleteReferralCommand>
    {
        private readonly IReferralRepository _repository;
        private readonly ILogger<DeleteReferralCommandHandler> _logger;
        public DeleteReferralCommandHandler(
            IReferralRepository repository,
            ILogger<DeleteReferralCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteReferralCommand request, CancellationToken cancellationToken)
        {
            var resultReferralToDelete = await _repository.DeleteAsync(request.Id);
            if (!resultReferralToDelete)
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Referral {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
