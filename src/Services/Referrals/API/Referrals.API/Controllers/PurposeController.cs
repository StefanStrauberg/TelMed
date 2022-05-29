using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referrals.Application.DTO.PurposeDtos;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Application.Features.Referral.Requests.Queries;

namespace Referrals.API.Controllers
{
    public class PurposeController : BaseController
    {
        private readonly IMediator _mediator;
        public PurposeController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:length(24)}/{purposeGroupId}")]
        [ProducesResponseType(typeof(PurposeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPurposeDetail(string id, int purposeGroupId)
            => Ok(await _mediator.Send(new GetPurposeDetailRequest(id, purposeGroupId)));

        [HttpPost("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePurpose([FromBody] PurposeDto model, string id)
            => Ok(await _mediator.Send(new CreatePurposeCommand(model, id)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePurpose([FromBody] PurposeDto model, string id)
            => Ok(await _mediator.Send(new UpdatePurposeCommand(model, id)));

        [HttpDelete("{id:length(24)}/{purposeGroupId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePurpose(string id, int purposeGroupId)
            => Ok(await _mediator.Send(new DeletePurposeCommand(id, purposeGroupId)));
    }
}