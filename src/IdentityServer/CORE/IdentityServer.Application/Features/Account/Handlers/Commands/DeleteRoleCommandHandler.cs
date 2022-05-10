using System.Net.Cache;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
            => _roleManager = roleManager;
        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.id);
            if(role is null)
                throw new RoleBadRequestException(request.id);
            await _roleManager.DeleteAsync(role);
            return Unit.Value;
        }
    }
}