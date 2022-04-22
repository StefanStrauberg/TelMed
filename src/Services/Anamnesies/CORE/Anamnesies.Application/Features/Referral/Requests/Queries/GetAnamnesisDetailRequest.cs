using Anamnesies.Application.DTO;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Queries
{
    public record GetAnamnesisDetailRequest(string id) : IRequest<AnamnesisDto>;
}
