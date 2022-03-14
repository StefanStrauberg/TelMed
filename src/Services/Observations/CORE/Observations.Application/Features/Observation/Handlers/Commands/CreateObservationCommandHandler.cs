using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Features.Observation.Requests.Commands;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class CreateObservationCommandHandler : IRequestHandler<CreateObservationCommand, string>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateObservationCommandHandler> _logger;
        public CreateObservationCommandHandler(
            IObservationsRepository repository,
            IMapper mapper,
            ILogger<CreateObservationCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(CreateObservationCommand request, CancellationToken cancellationToken)
        {
            var obsreavetionEntity = _mapper.Map<Domain.Observation>(request);
            await _repository.CreateAsync(obsreavetionEntity);
            _logger.LogInformation($"Observation {obsreavetionEntity.Id} in Referral {obsreavetionEntity.ReferralId} is successfully created.");
            return obsreavetionEntity.Id;
        }
    }
}
