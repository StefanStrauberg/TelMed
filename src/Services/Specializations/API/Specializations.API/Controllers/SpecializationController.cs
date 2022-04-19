using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Application.Features.Specialization.Requests.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Specializations.API.Controllers
{
    public class SpecializationController : BaseController
    {
        private readonly IMediator _mediator;
        public SpecializationController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<SpecializationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSpecializations()
        {
            return Ok(await _mediator.Send(new GetSpecializationListRequest()));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(SpecializationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdSpecialization(string id)
        {
            return Ok(await _mediator.Send(new GetSpecializationDetailRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationDto model)
        {
            return Ok(await _mediator.Send(new CreateSpecializationCommand(model)));
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationDto model, string id)
        {
            return Ok(await _mediator.Send(new UpdateSpecializationCommand(model, id)));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSpecialization(string id)
        {
            return Ok(await _mediator.Send(new DeleteSpecializationCommand(id)));
        }
    }
}
