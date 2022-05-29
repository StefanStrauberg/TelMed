using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Referrals.Application.DTO.AnamnesisDtos;
using Referrals.Application.Features.Referral.Requests.Commands;
using System.Threading.Tasks;

namespace Referrals.API.Controllers
{
    [Authorize]
    public class AnamnesisController : BaseController
    {
        private readonly IMediator _mediator;
        public AnamnesisController(IMediator mediator) => _mediator = mediator;

        [HttpPost("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnamnesis([FromBody] AnamnesisDto model, string id)
            => Ok(await _mediator.Send(new CreateAnamnesisCommand(model, id)));
    }
}
