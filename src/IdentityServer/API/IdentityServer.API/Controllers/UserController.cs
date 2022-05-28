using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediatR;
        public UserController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<AccountDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAccounts()
            => Ok(await _mediatR.Send(new GetAccountsListRequest()));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccountById(Guid id)
            => Ok(await _mediatR.Send(new GetAccountDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] AccountForRegistrationDto model)
            => Ok(await _mediatR.Send(new RegisterAccountCommand(model)));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAccountById(Guid id)
            => Ok(await _mediatR.Send(new DeleteAccountCommand(id)));
    }
}