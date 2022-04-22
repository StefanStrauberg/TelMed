using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referrals.Application.DTO;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Application.Features.Referral.Requests.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Referrals.API.Controllers
{
    public class ReferralController : BaseController
    {
        private readonly IMediator _mediator;
        public ReferralController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<ReferralDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllReferrals()
        {
            return Ok(await _mediator.Send(new GetReferralListRequest()));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(ReferralDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdReferral(string id)
        {
            return Ok(await _mediator.Send(new GetReferralDetailRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateReferral([FromBody] CreateReferralDto model)
        {
            return Ok(await _mediator.Send(new CreateReferralCommand(model)));
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateReferral([FromBody] UpdateReferralDto model, string id)
        {
            return Ok(await _mediator.Send(new UpdateReferralCommand(model, id)));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteReferral(string id)
        {
            return Ok(await _mediator.Send(new DeleteReferralCommand(id)));
        }
    }
}
