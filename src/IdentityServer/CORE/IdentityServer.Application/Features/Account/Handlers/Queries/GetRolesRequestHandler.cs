using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleMagaer;
        public GetRoleListRequestHandler(RoleManager<IdentityRole> roleMagaer)
            => _roleMagaer = roleMagaer;
        public Task<List<IdentityRole>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
            => Task.FromResult(_roleMagaer.Roles.ToList());
    }
}
