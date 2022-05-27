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
        public async Task<IActionResult> GetAllAccounts()
            => Ok(await _mediatR.Send(new GetAccountsListRequest()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
            => Ok(await _mediatR.Send(new GetAccountDetailRequest(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountById(Guid id)
            => Ok(await _mediatR.Send(new DeleteAccountCommand(id)));
    }
}