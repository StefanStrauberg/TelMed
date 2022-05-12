using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IMediator _mediatR;
        public RoleController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpPost("Register")]
        public async Task<IActionResult> Register(string roleName)
            => Ok(await _mediatR.Send(new RegisterRoleCommand(roleName)));

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
            => Ok(await _mediatR.Send(new GetRolesListRequest()));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllRoleById(Guid id)
            => Ok(await _mediatR.Send(new GetRoleDetailRequest(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleById(string id)
            => Ok(await _mediatR.Send(new DeleteRoleCommand(id)));
    }
}