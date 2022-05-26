using Anamnesies.Application.DTO;
using MediatR;

namespace Anamnesies.Application.Features.Referral.Requests.Queries
{
    public record GetAnamnesisListByRefferalIdRequest(string refferalId): IRequest<IReadOnlyList<AnamnesisDto>>;
}