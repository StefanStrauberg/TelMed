using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Organizations.Application.Contracts.Persistence;
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
            if (!await _repository.UpdateAsync(_mapper.Map<Domain.Organization>(request)))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Organization {request.Id} is successfully to updated.");
            return Unit.Value;
        }
    }
}
