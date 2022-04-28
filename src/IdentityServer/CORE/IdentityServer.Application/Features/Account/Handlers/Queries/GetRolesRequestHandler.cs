using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleMagaer;
        public GetRolesRequestHandler(RoleManager<IdentityRole> roleMagaer)
            => _roleMagaer = roleMagaer;
        public Task<List<IdentityRole>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleMagaer.Roles.ToList();
            return Task.FromResult(roles);
        } 
    }
}
