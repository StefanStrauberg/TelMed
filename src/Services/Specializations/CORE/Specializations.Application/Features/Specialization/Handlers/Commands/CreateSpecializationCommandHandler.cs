using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSpecializationCommandHandler> _logger;
        public CreateSpecializationCommandHandler(
            ISpecializationRepository repository,
            IMapper mapper,
            ILogger<CreateSpecializationCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specializationEntity = _mapper.Map<Domain.Specialization>(request);
            await _repository.CreateAsync(specializationEntity);
            _logger.LogInformation($"Specialization {specializationEntity.Id} is successfully created.");
            return Unit.Value;
        }
    }
}
