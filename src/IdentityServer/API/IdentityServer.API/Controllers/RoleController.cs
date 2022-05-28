using IdentityServer.Application.DTOs;
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

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<RoleDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoles()
            => Ok(await _mediatR.Send(new GetRolesListRequest()));
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRoleById(Guid id)
            => Ok(await _mediatR.Send(new GetRoleDetailRequest(id)));

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateRoleDto model)
            => Ok(await _mediatR.Send(new RegisterRoleCommand(model)));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteRoleById(Guid id)
            => Ok(await _mediatR.Send(new DeleteRoleCommand(id)));
    }
}