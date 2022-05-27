using MediatR;

namespace Purposes.Application.Features.Purpouse.Requests.Commands
{
    public record DeletePurposeCommand(string id) : IRequest;
}
