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
        [HttpGet(Name = "GetOrganizations")]
        [ProducesResponseType(typeof(List<Specialization>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Specialization>>> GetOrganizations()
        {
            return Ok(await _mediator.Send(new GetSpecializationListRequest()));
        }

        [HttpGet("id", Name = "GetOrganization")]
        [ProducesResponseType(typeof(Specialization), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Specialization>> GetOrganization(string id)
        {
            return Ok(await _mediator.Send(new GetSpecializationDetailRequest() { Id = id }));
        }

        [HttpPost(Name = "CreateOrganization")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateOrganization([FromBody] CreateSpecializationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrganization([FromBody] UpdateSpecializationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}", Name = "DeleteOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrganization(string id)
        {
            await _mediator.Send(new DeleteSpecializationCommand() { Id = id });
            return Ok();
        }
    }
}
