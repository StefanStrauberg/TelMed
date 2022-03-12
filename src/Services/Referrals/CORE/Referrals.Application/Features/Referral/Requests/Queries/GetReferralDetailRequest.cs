using MediatR;
using Referrals.Application.DTO;

namespace Referrals.Application.Features.Referral.Requests.Queries
{
    public class GetReferralDetailRequest : IRequest<ReferralDto>
    {
        public string Id { get; set; }
    }
}
