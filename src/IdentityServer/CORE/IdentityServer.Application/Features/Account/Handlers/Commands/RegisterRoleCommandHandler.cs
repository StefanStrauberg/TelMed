﻿using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class RegisterRoleCommandHandler : IRequestHandler<RegisterRoleCommand, Unit>
    {
        private readonly RoleManager<Domain.ApplicationRole> _roleManager;
        public RegisterRoleCommandHandler(RoleManager<Domain.ApplicationRole> roleManager)
            => _roleManager = roleManager;
        public async Task<Unit> Handle(RegisterRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _roleManager.RoleExistsAsync(request.roleName))
                throw new ExistsRoleBadRequestException(request.roleName);
            await _roleManager.CreateAsync(new Domain.ApplicationRole() { Name = request.roleName });
            return Unit.Value;
        }
    }
}
