using ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Requests;
using ImagingStudies.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ImagingStudies.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagingStudyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ImagingStudyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllImagingStudies")]
        [ProducesResponseType(typeof(IReadOnlyList<ImagingStudy>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<ImagingStudy>>> GetAllImagingStudies()
        {
            return Ok(await _mediator.Send(new GetImagingStudiyListRequest()));
        }

        [HttpGet("{id:length(24)}", Name = "GetByIdImagingStudy")]
        [ProducesResponseType(typeof(ImagingStudy), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ImagingStudy>> GetByIdImagingStudy(string id)
        {
            return Ok(await _mediator.Send(new GetImagingStudiyDetailRequest() { Id = id }));
        }

        [HttpPost(Name = "CreateSpecialization")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateSpecialization([FromBody] CreateImagingStudiyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateSpecialization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSpecialization([FromBody] UpdateImagingStudiyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteSpecialization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSpecialization(string id)
        {
            return Ok(await _mediator.Send(new DeleteImagingStudiyCommand() { Id = id }));
        }
    }
}
