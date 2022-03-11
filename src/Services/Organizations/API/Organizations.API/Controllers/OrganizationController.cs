using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Features.Organization.Requests.Queries;
using Organizations.Domain;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Organizations.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetOrganizations")]
        [ProducesResponseType(typeof(List<Organization>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Organization>>> GetOrganizations()
        {
            return Ok(await _mediator.Send(new GetOrganizationListRequest()));
        }

        [HttpGet("id", Name = "GetOrganization")]
        [ProducesResponseType(typeof(Organization), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Organization>> GetOrganization(string id)
        {
            return Ok(await _mediator.Send(new GetOrganizationDetailRequest() { Id = id }));
        }

        [HttpPost(Name = "CreateOrganization")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateOrganization([FromBody] CreateOrganizationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}", Name = "DeleteOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrganization(string id)
        {
            await _mediator.Send(new DeleteOrganizationCommand() { Id = id });
            return Ok();
        }
    }
}
