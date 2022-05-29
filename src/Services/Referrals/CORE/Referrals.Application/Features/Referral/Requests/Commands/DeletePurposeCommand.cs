using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record DeletePurposeCommand(int purposeGroup, string referralId) : IRequest;
}
