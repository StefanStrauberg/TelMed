using MediatR;
using Referrals.Application.DTO.ReferralDtos;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record CreateReferralCommand(CreateReferralDto model, string accountId) : IRequest;
}
