using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralDetailRequestHandler : IRequestHandler<GetReferralDetailRequest, Domain.Referral>
    {
        private readonly IReferralRepository _repository;
        public GetReferralDetailRequestHandler(IReferralRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Referral> Handle(GetReferralDetailRequest request, CancellationToken cancellationToken)
        {
            var referral = await _repository.GetAsync(request.Id);
            if (referral is null)
                throw new NotFoundException(nameof(request), request.Id);
            return referral;
        }
    }
}
