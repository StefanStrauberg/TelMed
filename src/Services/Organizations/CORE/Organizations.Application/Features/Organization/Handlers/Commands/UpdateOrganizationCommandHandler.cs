using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.DTOs.Organization;
using Organizations.Application.Exceptions;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IOrganizationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrganizationCommandHandler> _logger;
        public UpdateOrganizationCommandHandler(
            IOrganizationRepository repository,
            IMapper mapper,
            ILogger<UpdateOrganizationCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationToUpdate = await _repository.GetAsync(request.OrganizationDto.Id);
            if(organizationToUpdate is null)
                throw new NotFoundException(nameof(request.OrganizationDto), request.OrganizationDto.Id);
            _mapper.Map(request.OrganizationDto, organizationToUpdate, typeof(OrganizationDto), typeof(Domain.Organization));
            await _repository.UpdateAsync(organizationToUpdate);
            _logger.LogInformation($"Organization {organizationToUpdate.Id} is successfully to updated.");
            return Unit.Value;
        }
    }
}
