using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Features.Organization.Requests.Queries;

namespace Organizations.API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly IMediator _mediator;
        public BuggyController(IMediator mediator) => _mediator = mediator;

        [HttpGet("NotFound")]
        public async Task<IActionResult> GetNotFound()
        {
            var model = await _mediator.Send(new GetOrganizationDetailRequest("622eed3c1b6c09a6a765281f"));
            return Ok(model);
        }

        [HttpGet("ServerError")]
        public async Task<IActionResult> GetServerError()
        {
            var model = await _mediator.Send(new UpdateOrganizationCommand(
                new UpdateOrganizationDto {
                    Level = Domain.OrganizationLevel.RepublicLevel,
                    Region = Domain.OrganizationRegion.Belarus,
                    Address = 
                    {
                        Line = "Testing string Address"
                    },
                    IsActive = true,
                    OrganizationName = 
                    {
                        UsualName = "Testing Abbreviated Name Adter Put",
                        OfficialName = "Testing Full Name After Put"
                    },
                    SpecializationIds = null
                }, "62541d28e00cb73e1d10acae"
            ));
            return Ok(model);
        }

        [HttpGet("BadRequest")]
        public async Task<IActionResult> GetBadRequest()
        {
            var model = await _mediator.Send(new DeleteOrganizationCommand("622eed3c1b6c09a6a765281f"));
            return Ok(model);
        }
    }
}