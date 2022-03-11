using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTOs.Organization;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, string>
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
        public async Task<string> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationEntity = _mapper.Map<Domain.Organization>(request.OrganizationDto);
            var newOrganization = await _repository.CreateAsync(organizationEntity);
            _logger.LogInformation($"Organization {newOrganization} is successfully created.");
            return newOrganization;
        }
    }
}
