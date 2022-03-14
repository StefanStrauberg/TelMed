using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Application.Features.Referral.Requests.Queries;
using Referrals.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Referrals.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferralController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReferralController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllReferrals")]
        [ProducesResponseType(typeof(IReadOnlyList<Referral>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Referral>>> GetAllReferrals()
        {
            return Ok(await _mediator.Send(new GetReferralListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdReferral")]
        [ProducesResponseType(typeof(Referral), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Referral>> GetByIdReferral(string id)
        {
            return Ok(await _mediator.Send(new GetReferralDetailRequest() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateReferral([FromBody] CreateReferralCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateReferral([FromBody] UpdateReferralCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteReferral")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteReferral(string id)
        {
            return Ok(await _mediator.Send(new DeleteReferralCommand() { Id = id }));
        }
    }
}
