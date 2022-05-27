using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Commands
{
    public record DeleteAccountCommand(Guid id) : IRequest;
}
