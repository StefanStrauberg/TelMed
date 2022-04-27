using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        public Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
