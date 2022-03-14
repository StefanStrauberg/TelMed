using MediatR;
using Referrals.Domain;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public class UpdateReferralCommand : IRequest
    {
        public string Id { get; set; }
        public Patient Patient { get; set; }
    }
}
