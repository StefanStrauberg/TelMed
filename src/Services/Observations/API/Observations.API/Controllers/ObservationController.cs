using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Observations.Application.DTO;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Application.Features.Observation.Requests.Queries;
using Observations.Application.Helpers;
using Observations.Application.Specs;
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
        [ProducesResponseType(typeof(IReadOnlyList<Pagination<ObservationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllObservations([FromQuery] QuerySpecParams querySpecParams)
            => Ok(new Pagination<ObservationDto>(
                    pageIndex: querySpecParams.PageIndex,
                    pageSize: querySpecParams.PageSize,
                    count: await _mediator.Send(new GetObservationsCountRequest(querySpecParams)),
                    data: await _mediator.Send(new GetObservationListRequest(querySpecParams))
                ));

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(ObservationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdObservation(string id)
            => Ok(await _mediator.Send(new GetObservationDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateObservation([FromBody] CreateObservationDto model)
            => Ok(await _mediator.Send(new CreateObservationCommand(model)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateObservation([FromBody] UpdateObservationDto model, string id)
            => Ok(await _mediator.Send(new UpdateObservationCommand(model, id)));

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteObservation(string id)
            => Ok(await _mediator.Send(new DeleteObservationCommand(id)));
    }
}
