using IdentityServer.Application.DTOs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Commands
{
    public record LoginAccountCommand(AccountForAuthenticationDto model) : IRequest<AuthResponseDto>;
}
