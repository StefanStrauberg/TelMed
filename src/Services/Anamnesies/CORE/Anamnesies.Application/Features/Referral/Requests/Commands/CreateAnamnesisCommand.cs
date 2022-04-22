using Anamnesies.Application.DTO;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Commands
{
    public record CreateAnamnesisCommand(CreateAnamnesisDto model) : IRequest;
}
