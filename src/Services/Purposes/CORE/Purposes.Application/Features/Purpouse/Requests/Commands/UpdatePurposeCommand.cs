using MediatR;
using Purposes.Application.DTO;

namespace Purposes.Application.Features.Purpouse.Requests.Commands
{
    public record UpdatePurposeCommand(UpdatePurposeDto model, string id) : IRequest;
}
