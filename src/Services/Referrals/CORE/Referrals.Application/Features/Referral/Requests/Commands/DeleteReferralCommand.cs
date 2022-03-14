using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public class DeleteReferralCommand : IRequest
    {
        public string Id { get; set; }
    }
}
