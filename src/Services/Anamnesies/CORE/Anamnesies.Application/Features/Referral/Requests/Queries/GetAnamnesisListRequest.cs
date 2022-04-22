using Anamnesies.Application.DTO;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Queries
{
    public record GetAnamnesisListRequest : IRequest<IReadOnlyList<AnamnesisDto>>;
}
