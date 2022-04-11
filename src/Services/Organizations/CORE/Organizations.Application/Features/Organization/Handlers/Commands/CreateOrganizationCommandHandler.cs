﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrganizationCommandHandler> _logger;
        public CreateOrganizationCommandHandler(
            IOrganizationRepository repository,
            IMapper mapper,
            ILogger<CreateOrganizationCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationEntity = _mapper.Map<Domain.Organization>(request);
            await _repository.CreateAsync(organizationEntity);
            _logger.LogInformation($"Organization {organizationEntity.Id} is successfully created.");
            return Unit.Value;
        }
    }
}
