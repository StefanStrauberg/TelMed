using MediatR;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.Application.Features.Referral.Handlers.Queries
{
    public class GetReferralListRequestHandler : IRequestHandler<GetReferralListRequest, IReadOnlyList<Domain.Referral>>
    {
        private readonly IReferralRepository _repository;
        public GetReferralListRequestHandler(IReferralRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<Domain.Referral>> Handle(GetReferralListRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(); ;
        }
    }
}
