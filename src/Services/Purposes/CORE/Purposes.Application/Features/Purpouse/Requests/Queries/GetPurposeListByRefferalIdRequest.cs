using MediatR;
using Purposes.Application.DTO;

namespace Purposes.Application.Features.Purpouse.Requests.Queries
{
    public record GetPurposeListByRefferalIdRequest(string id) : IRequest<IReadOnlyList<PurposeDto>>;
}