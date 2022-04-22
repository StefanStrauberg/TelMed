using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Commands
{
    public record DeleteAnamnesisCommand(string id) : IRequest;
}
