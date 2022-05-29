using MediatR;
using Referrals.Application.DTO.PurposeDtos;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record UpdatePurposeCommand(PurposeDto model, string referralId) : IRequest;
}
