using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly IMediator _mediatR;
        public RegisterController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AccountForRegistrationDto model)
            => Ok(await _mediatR.Send(new RegisterAccountCommand(model)));
    }
}
