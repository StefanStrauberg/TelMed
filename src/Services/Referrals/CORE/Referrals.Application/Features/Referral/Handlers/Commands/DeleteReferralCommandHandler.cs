using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Errors;
using Referrals.Application.Features.Referral.Requests.Commands;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class DeleteReferralCommandHandler : IRequestHandler<DeleteReferralCommand>
    {
        private readonly IReferralRepository _repository;
        public DeleteReferralCommandHandler(IReferralRepository repository) 
            => _repository = repository;
        public async Task<Unit> Handle(DeleteReferralCommand request, CancellationToken cancellationToken)
        {
            if(await _repository.DeleteAsync(request.referralId))
                return Unit.Value;
            throw new ReferralBadRequestException(request.referralId);
        }
    }
}
