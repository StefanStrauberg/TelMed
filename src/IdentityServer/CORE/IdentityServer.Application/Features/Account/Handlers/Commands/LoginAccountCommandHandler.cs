using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, AuthResponseDto>
    {
        public Task<AuthResponseDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
