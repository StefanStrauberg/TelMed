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
        [HttpGet(Name = "GetAllOrganizations")]
        [ProducesResponseType(typeof(List<Organization>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Organization>>> GetAllOrganizations()
        {
            return Ok(await _mediator.Send(new GetOrganizationListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdOrganization")]
        [ProducesResponseType(typeof(Organization), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Organization>> GetByIdOrganization(string id)
        {
            return Ok(await _mediator.Send(new GetOrganizationDetailRequest() { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateOrganization([FromBody] CreateOrganizationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrganization([FromBody] UpdateOrganizationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrganization(string id)
        {
            return Ok(await _mediator.Send(new DeleteOrganizationCommand() { Id = id }));
        }
    }
}
