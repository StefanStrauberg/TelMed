using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record DeletePurposeCommand(string referralId, int purposeGroupId) : IRequest;
}
