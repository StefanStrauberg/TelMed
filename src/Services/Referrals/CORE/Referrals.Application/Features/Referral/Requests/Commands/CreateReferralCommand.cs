using MediatR;
using Referrals.Application.DTO;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record CreateReferralCommand(CreateReferralDto model, string accountId) : IRequest;
}
