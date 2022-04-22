using MediatR;
using Referrals.Application.DTO;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record UpdateReferralCommand(UpdateReferralDto model, string id) : IRequest;
}
