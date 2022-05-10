using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleDetailRequestHandler : IRequestHandler<GetRoleDetailRequest, IdentityRole>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public GetRoleDetailRequestHandler(RoleManager<IdentityRole> roleManager)
            => _roleManager = roleManager;
        public async Task<IdentityRole> Handle(GetRoleDetailRequest request, CancellationToken cancellationToken)
            => await _roleManager.FindByIdAsync(request.id);
    }
}