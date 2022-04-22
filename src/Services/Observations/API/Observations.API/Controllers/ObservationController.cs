using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Observations.Application.DTO;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Application.Features.Observation.Requests.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Observations.API.Controllers
{
    public class ObservationController : BaseController
    {
        private readonly IMediator _mediator;
        public ObservationController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<ObservationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllObservations()
        {
            return Ok(await _mediator.Send(new GetObservationListRequest()));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(ObservationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdObservation(string id)
        {
            return Ok(await _mediator.Send(new GetObservationDetailRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateObservation([FromBody] CreateObservationDto model)
        {
            return Ok(await _mediator.Send(new CreateObservationCommand(model)));
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateObservation([FromBody] UpdateObservationDto model, string id)
        {
            return Ok(await _mediator.Send(new UpdateObservationCommand(model, id)));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteObservation(string id)
        {
            return Ok(await _mediator.Send(new DeleteObservationCommand(id)));
        }
    }
}
