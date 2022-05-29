using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record DeleteAnamnesisCommand(string referralId, int anamnesisCategoryId) : IRequest;
}
