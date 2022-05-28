using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Purposes.Application.DTO;
using Purposes.Application.Features.Purpouse.Requests.Commands;
using Purposes.Application.Features.Purpouse.Requests.Queries;

namespace Purposes.API.Controllers
{
    [Authorize]
    public class PurposeController : BaseController
    {
        private readonly IMediator _mediator;
        public PurposeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<PurposeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPurposes()
            => Ok(await _mediator.Send(new GetPurposeListRequest()));

        [HttpGet("ByReferralId/{id:length(24)}")]
        [ProducesResponseType(typeof(IReadOnlyList<PurposeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPurposeListByRefferalIdRequest(string id)
        {
            return Ok(await _mediator.Send(new GetPurposeListByRefferalIdRequest(id)));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(PurposeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdPurpose(string id)
            => Ok(await _mediator.Send(new GetPurposeDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePurpose([FromBody] CreatePurposeDto model)
            => Ok(await _mediator.Send(new CreatePurposeCommand(model)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePurpose([FromBody] UpdatePurposeDto model, string id)
            => Ok(await _mediator.Send(new UpdatePurposeCommand(model, id)));

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePurpose(string id)
            => Ok(await _mediator.Send(new DeletePurposeCommand(id)));
    }
}
