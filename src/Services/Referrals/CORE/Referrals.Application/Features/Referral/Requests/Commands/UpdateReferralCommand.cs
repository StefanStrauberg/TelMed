using MediatR;
using Referrals.Application.DTO.ReferralDtos;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record UpdateReferralCommand(UpdateReferralDto model, string referralId) : IRequest;
}
