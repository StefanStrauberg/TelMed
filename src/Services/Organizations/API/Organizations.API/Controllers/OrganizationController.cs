using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
