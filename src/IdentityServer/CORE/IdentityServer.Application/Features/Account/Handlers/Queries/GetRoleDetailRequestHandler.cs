using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleDetailRequestHandler : IRequestHandler<GetRoleDetailRequest, Domain.ApplicationRole>
    {
        private readonly RoleManager<Domain.ApplicationRole> _roleManager;
        public GetRoleDetailRequestHandler(RoleManager<Domain.ApplicationRole> roleManager)
            => _roleManager = roleManager;
        public async Task<Domain.ApplicationRole> Handle(GetRoleDetailRequest request, CancellationToken cancellationToken)
            => await _roleManager.FindByIdAsync(request.id);
    }
}