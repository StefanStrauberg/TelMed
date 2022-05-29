using MediatR;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public record DeleteAnamnesisCommand(int anamnesisCategory,string referralId) : IRequest;
}
