using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IMediator _mediatR;
        public LoginController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountForAuthenticationDto model)
            => Ok(await _mediatR.Send(new LoginAccountCommand(model)));
    }
}
