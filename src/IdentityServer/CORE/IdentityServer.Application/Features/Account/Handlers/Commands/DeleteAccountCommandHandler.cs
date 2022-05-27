using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        public DeleteAccountCommandHandler(UserManager<Domain.ApplicationUser> userManager)
            => _userManager = userManager;
        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.id.ToString());
            if (account is null)
                throw new AccountBadRequestException(request.id.ToString());
            await _userManager.DeleteAsync(account);
            return Unit.Value;
        }
    }
}
