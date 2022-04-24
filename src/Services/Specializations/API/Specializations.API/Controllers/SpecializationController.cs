using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Application.Features.Specialization.Requests.Queries;
using Specializations.Application.Helpers;
using Specializations.Application.Specs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Specializations.API.Controllers
{
    public class SpecializationController : BaseController
    {
        private readonly IMediator _mediator;
        public SpecializationController(IMediator mediator) 
            => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<Pagination<SpecializationDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSpecializations([FromQuery] QuerySpecParams querySpecParams)
            => Ok(new Pagination<SpecializationDto>(
                pageIndex: querySpecParams.PageIndex,
                pageSize: querySpecParams.PageSize,
                count: await _mediator.Send(new GetSpecializationsCountRequest(querySpecParams)),
                data: await _mediator.Send(new GetSpecializationListRequest(querySpecParams))
            ));

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
