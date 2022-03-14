using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Application.Features.Specialization.Requests.Queries;
using Specializations.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Specializations.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecializationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllSpecializations")]
        [ProducesResponseType(typeof(IReadOnlyList<Specialization>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Specialization>>> GetAllSpecializations()
        {
            return Ok(await _mediator.Send(new GetSpecializationListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdSpecialization")]
        [ProducesResponseType(typeof(Specialization), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Specialization>> GetByIdSpecialization(string id)
        {
            return Ok(await _mediator.Send(new GetSpecializationDetailRequest() { Id = id }));
        }

        [HttpPost(Name = "CreateSpecialization")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateSpecialization([FromBody] CreateSpecializationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateSpecialization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSpecialization([FromBody] UpdateSpecializationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteSpecialization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSpecialization(string id)
        {
            return Ok(await _mediator.Send(new DeleteSpecializationCommand() { Id = id }));
        }
    }
}
