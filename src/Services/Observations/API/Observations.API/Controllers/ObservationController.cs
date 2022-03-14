using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Application.Features.Observation.Requests.Queries;
using Observations.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Observations.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ObservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllObservations")]
        [ProducesResponseType(typeof(IReadOnlyList<Observation>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Observation>>> GetAllObservations()
        {
            return Ok(await _mediator.Send(new GetObservationListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdObservation")]
        [ProducesResponseType(typeof(Observation), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Observation>> GetByIdObservation(string id)
        {
            return Ok(await _mediator.Send(new GetObservationDetailRequest() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateObservation([FromBody] CreateObservationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> UpdateObservation([FromBody] UpdateObservationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteObservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteObservation(string id)
        {
            return Ok(await _mediator.Send(new DeleteObservationCommand() { Id = id }));
        }
    }
}
