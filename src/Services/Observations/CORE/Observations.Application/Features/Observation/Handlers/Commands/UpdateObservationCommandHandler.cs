using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Observations.Application.Contracts.Persistence;
using Observations.Application.Exceptions;
using Observations.Application.Features.Observation.Requests.Commands;

namespace Observations.Application.Features.Observation.Handlers.Commands
{
    public class UpdateObservationCommandHandler : IRequestHandler<UpdateObservationCommand>
    {
        private readonly IObservationsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateObservationCommandHandler> _logger;
        public UpdateObservationCommandHandler(
            IObservationsRepository repository,
            ILogger<UpdateObservationCommandHandler> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateObservationCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.UpdateAsync(_mapper.Map<Domain.Observation>(request)))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Observation {request.Id} in Referral {request.ReferralId} is successfully updated.");
            return Unit.Value;
        }
    }
}
