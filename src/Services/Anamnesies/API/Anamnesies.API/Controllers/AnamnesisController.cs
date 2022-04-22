using Anamnesies.Application.DTO;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anamnesies.API.Controllers
{
    public class AnamnesisController : BaseController
    {
        private readonly IMediator _mediator;
        public AnamnesisController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<AnamnesisDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAnamnesis()
        {
            return Ok(await _mediator.Send(new GetAnamnesisListRequest()));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(AnamnesisDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdAnamnesis(string id)
        {
            return Ok(await _mediator.Send(new GetAnamnesisDetailRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnamnesis([FromBody] CreateAnamnesisDto model)
        {
            return Ok(await _mediator.Send(new CreateAnamnesisCommand(model)));
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAnamnesis([FromBody] UpdateAnamnesisDto model, string id)
        {
            return Ok(await _mediator.Send(new UpdateAnamnesisCommand(model, id)));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAnamnesis(string id)
        {
            return Ok(await _mediator.Send(new DeleteAnamnesisCommand(id)));
        }
    }
}
