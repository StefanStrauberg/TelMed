using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anamnesies.Application.Features.Referral.Handlers.Commands
{
    public class CreateAnamnesisCommandHandler : IRequestHandler<CreateAnamnesisCommand, string>
    {
        private readonly IAnamnesisRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAnamnesisCommandHandler> _logger;
        public CreateAnamnesisCommandHandler(
            IAnamnesisRepository repository,
            IMapper mapper,
            ILogger<CreateAnamnesisCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(CreateAnamnesisCommand request, CancellationToken cancellationToken)
        {
            var anamnesisEntity = _mapper.Map<Anamnesis>(request);
            await _repository.CreateAsync(anamnesisEntity);
            _logger.LogInformation($"Anamnesis {anamnesisEntity.Id} in Referral {anamnesisEntity.ReferralId} is successfully created.");
            return anamnesisEntity.Id;
        }
    }
}
