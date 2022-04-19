﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Application.Features.Organization.Requests.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organizations.API.Controllers
{
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        public OrganizationController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<OrganizationDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrganizations()
        {
            return Ok(await _mediator.Send(new GetOrganizationListRequest()));
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdOrganization(string id)
        {
            return Ok(await _mediator.Send(new GetOrganizationDetailRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDto model)
        {
            return Ok(await _mediator.Send(new CreateOrganizationCommand(model)));
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOrganizationDto model, string id)
        {
            return Ok(await _mediator.Send(new UpdateOrganizationCommand(model, id)));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrganization(string id)
        {
            return Ok(await _mediator.Send(new DeleteOrganizationCommand(id)));
        }
    }
}
