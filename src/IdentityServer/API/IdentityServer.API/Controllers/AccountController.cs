using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Application.Helpers;
using IdentityServer.Application.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediatR;
        public AccountController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<Pagination<AccountDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrganizations([FromQuery] QuerySpecParams querySpecParams)
            => Ok(new Pagination<AccountDto>(
                pageIndex: querySpecParams.PageIndex,
                pageSize: querySpecParams.PageSize,
                count: await _mediatR.Send(new GetAccountsCountRequest(querySpecParams)),
                data: await _mediatR.Send(new GetAccountsListRequest(querySpecParams))
            ));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
            => Ok(await _mediatR.Send(new GetAccountDetailRequest(id)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountById(string id)
            => Ok(await _mediatR.Send(new DeleteAccountCommand(id)));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountById([FromBody] AccountForUpdateDto model, string id)
            => Ok(await _mediatR.Send(new UpdateAccountCommand(model , id)));
        
    }
}