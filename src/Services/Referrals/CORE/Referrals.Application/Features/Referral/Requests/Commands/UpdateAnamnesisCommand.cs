using MediatR;
using Referrals.Application.DTO.AnamnesisDtos;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record UpdateAnamnesisCommand(AnamnesisDto model, string referralId) : IRequest;
}
