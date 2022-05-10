using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediatR;
        public AccountController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AccountForRegistrationDto model)
            => Ok(await _mediatR.Send(new RegisterAccountCommand(model)));

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountForAuthenticationDto model)
            => Ok(await _mediatR.Send(new LoginAccountCommand(model)));

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
            => Ok(await _mediatR.Send(new GetAccountListRequest()));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(string id)
            => Ok(await _mediatR.Send(new GetAccountDetailRequest(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountById(string id)
            => Ok(await _mediatR.Send(new DeleteAccountCommand(id)));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountById([FromBody] AccountForUpdateDto model, string id)
            => Ok(await _mediatR.Send(new UpdateAccountCommand(model , id)));
        
    }
}