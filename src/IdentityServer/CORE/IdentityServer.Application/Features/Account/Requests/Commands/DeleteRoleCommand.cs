using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Commands
{
    public record DeleteRoleCommand(Guid id) : IRequest;
}