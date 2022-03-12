using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Anamnesis.Requests.Commands;

namespace Referrals.Application.Features.Anamnesis.Handlers.Commands
{
    public class CreateAnamnesisCommandHandler : IRequestHandler<CreateAnamnesisCommand>
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
        public async Task<Unit> Handle(CreateAnamnesisCommand request, CancellationToken cancellationToken)
        {
            var anamnesisEntity = _mapper.Map<Domain.AnamnesisEntity.Anamnesis>(request);
            if (!await _repository.CreateAsync(anamnesisEntity, request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Anamnesis Referral:{request.Id} is successfully created.");
            return Unit.Value;
        }
    }
}
