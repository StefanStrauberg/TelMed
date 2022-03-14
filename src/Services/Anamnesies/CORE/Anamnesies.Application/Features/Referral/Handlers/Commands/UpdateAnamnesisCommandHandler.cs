using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Exceptions;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class UpdateAnamnesisCommandHandler : IRequestHandler<UpdateAnamnesisCommand>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAnamnesisCommandHandler> _logger;
        public UpdateAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IMapper mapper,
            ILogger<UpdateAnamnesisCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateAnamnesisCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.UpdateAsync(_mapper.Map<Anamnesis>(request)))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Anamnesis {request.Id} in Referral {request.ReferralId} is successfully updated.");
            return Unit.Value;
        }
    }
}
