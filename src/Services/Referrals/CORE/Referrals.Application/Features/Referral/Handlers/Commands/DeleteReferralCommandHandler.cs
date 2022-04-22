using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain.Exceptions;

namespace Referrals.Application.Features.Referral.Handlers.Commands
{
    public class DeleteReferralCommandHandler : IRequestHandler<DeleteReferralCommand>
    {
        private readonly IReferralRepository _repository;
        public DeleteReferralCommandHandler(IReferralRepository repository) 
            => _repository = repository;
        public async Task<Unit> Handle(DeleteReferralCommand request, CancellationToken cancellationToken)
        {
            if(await _repository.DeleteAsync(request.id))
                return Unit.Value;
            throw new ReferralBadRequestException(request.id);
        }
    }
}
