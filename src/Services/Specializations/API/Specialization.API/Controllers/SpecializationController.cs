using BaseDomain.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Application.Features.Specialization.Requests.Queries;
using System.Text.Json;

namespace Specialization.API.Controllers
{
    public class SpecializationController : BaseController
    {
        private readonly IMediator _mediator;
        public SpecializationController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SpecializationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSpecializations([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetSpecializationListRequest(querySpecParams));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            }));
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SpecializationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdSpecialization(Guid id)
            => Ok(await _mediator.Send(new GetSpecializationDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationDto model)
            => Ok(await _mediator.Send(new CreateSpecializationCommand(model)));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationDto model, Guid id)
            => Ok(await _mediator.Send(new UpdateSpecializationCommand(model, id)));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSpecialization(Guid id)
            => Ok(await _mediator.Send(new DeleteSpecializationCommand(id)));
    }
}
