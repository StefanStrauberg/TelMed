using BaseDomain.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Features.Organization.Requests.Queries;
using System.Text.Json;

namespace Organization.API.Controllers
{
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(List<OrganizationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrganizations([FromQuery] QuerySpecParams querySpecParams)
        {
            var result = await _mediator.Send(new GetOrganizationListRequest(querySpecParams));
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdOrganization(Guid id)
            => Ok(await _mediator.Send(new GetOrganizationDetailRequest(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto model)
            => Ok(await _mediator.Send(new CreateOrganizationCommand(model)));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationDto model, Guid id)
            => Ok(await _mediator.Send(new UpdateOrganizationCommand(model, id)));

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrganization(Guid id)
            => Ok(await _mediator.Send(new DeleteOrganizationCommand(id)));
    }
}
