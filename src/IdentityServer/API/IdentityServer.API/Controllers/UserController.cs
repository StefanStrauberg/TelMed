using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Application.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdentityServer.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediatR;
        public UserController(IMediator mediatR)
            => _mediatR = mediatR;

        [HttpGet]
        [ProducesResponseType(typeof(List<AccountDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrganizations([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediatR.Send(new GetAccountsListRequest(querySpecParams));
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            })
            );
            return Ok(result);
        }

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