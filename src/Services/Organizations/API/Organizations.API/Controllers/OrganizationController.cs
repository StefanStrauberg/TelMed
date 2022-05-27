using BaseDomain.Specs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Features.Organization.Requests.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organizations.API.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(List<OrganizationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrganizations([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetOrganizationListRequest(querySpecParams));
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
        public async Task<IActionResult> GetShort()
            => Ok(await _mediator.Send(new GetShortAllOrganizationsRequest()));

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdOrganization(string id)
            => Ok(await _mediator.Send(new GetOrganizationDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto model)
            => Ok(await _mediator.Send(new CreateOrganizationCommand(model)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationDto model, string id)
            => Ok(await _mediator.Send(new UpdateOrganizationCommand(model, id)));

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrganization(string id)
            => Ok(await _mediator.Send(new DeleteOrganizationCommand(id)));
    }
}
