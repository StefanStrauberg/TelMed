using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Commands
{
    public record RegisterRoleCommand(string roleName) : IRequest;
}
