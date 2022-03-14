using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public class GetReferralDetailRequest : IRequest<Domain.Referral>
    {
        public string Id { get; set; }
    }
}
