using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record DeleteReferralCommand(string id) : IRequest;
}
