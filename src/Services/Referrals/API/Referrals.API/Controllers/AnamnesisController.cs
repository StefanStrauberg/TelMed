using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referrals.Application.DTO.AnamnesisDtos;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Application.Features.Referral.Requests.Queries;
using System.Threading.Tasks;

namespace Referrals.API.Controllers
{
    [Authorize]
    public class AnamnesisController : BaseController
    {
        private readonly IMediator _mediator;
        public AnamnesisController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id:length(24)}/{categoryId}")]
        [ProducesResponseType(typeof(AnamnesisDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAnamnesisDetail(string id, int categoryId)
            => Ok(await _mediator.Send(new GetAnamnesisDetailRequest(id, categoryId)));

        [HttpPost("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnamnesis([FromBody] AnamnesisDto model, string id)
            => Ok(await _mediator.Send(new CreateAnamnesisCommand(model, id)));

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAnamnesis([FromBody] AnamnesisDto model, string id)
            => Ok(await _mediator.Send(new UpdateAnamnesisCommand(model, id)));

        [HttpDelete("{id:length(24)}/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAnamnesis(string id, int categoryId)
            => Ok(await _mediator.Send(new DeleteAnamnesisCommand(id, categoryId)));
    }
}
