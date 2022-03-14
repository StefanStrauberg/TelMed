using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using Anamnesies.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Anamnesies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnamnesisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnamnesisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAnamnesis")]
        [ProducesResponseType(typeof(IReadOnlyList<Anamnesis>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Anamnesis>>> GetAllAnamnesis()
        {
            return Ok(await _mediator.Send(new GetAnamnesisListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdAnamnesis")]
        [ProducesResponseType(typeof(Anamnesis), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Anamnesis>> GetByIdAnamnesis(string id)
        {
            return Ok(await _mediator.Send(new GetAnamnesisDetailRequest() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateAnamnesis([FromBody] CreateAnamnesisCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateAnamnesis([FromBody] UpdateAnamnesisCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteAnamnesis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAnamnesis(string id)
        {
            return Ok(await _mediator.Send(new DeleteAnamnesisCommand() { Id = id }));
        }
    }
}
