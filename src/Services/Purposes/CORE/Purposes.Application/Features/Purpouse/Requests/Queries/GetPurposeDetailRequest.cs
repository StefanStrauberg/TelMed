using MediatR;
using Purposes.Application.DTO;

namespace Purposes.Application.Features.Purpouse.Requests.Queries
{
    public record GetPurposeDetailRequest(string id) : IRequest<PurposeDto>;
}
