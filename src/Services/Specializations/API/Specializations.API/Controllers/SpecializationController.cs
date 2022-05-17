using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Application.Features.Specialization.Requests.Queries;
using Specializations.Application.Helpers;
using Specializations.Application.Specs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Specializations.API.Controllers
{
    [Authorize]
    public class SpecializationController : BaseController
    {
        private readonly IMediator _mediator;
        public SpecializationController(IMediator mediator) 
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(List<SpecializationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSpecializations([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetSpecializationListRequest(querySpecParams));
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            })
                );
            return Ok(result);
        }

        [HttpGet("GetShort")]
        public async Task<IActionResult> GetShortSpecializations()
            =>Ok(await _mediator.Send(new GetShortSpecializations()));

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(SpecializationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdSpecialization(string id)
            => Ok(await _mediator.Send(new GetSpecializationDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreateSpecializationDto model)
            => Ok(await _mediator.Send(new CreateSpecializationCommand(model)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSpecialization([FromBody] UpdateSpecializationDto model, string id)
            => Ok(await _mediator.Send(new UpdateSpecializationCommand(model, id)));

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSpecialization(string id)
            => Ok(await _mediator.Send(new DeleteSpecializationCommand(id)));
    }
}
