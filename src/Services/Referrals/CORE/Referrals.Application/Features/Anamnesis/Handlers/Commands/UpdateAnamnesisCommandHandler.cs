using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Anamnesis.Requests.Commands;

namespace Referrals.Application.Features.Anamnesis.Handlers.Commands
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
            var anamnesisToUpdate = _mapper.Map<Domain.AnamnesisEntity.Anamnesis>(request);
            if (!await _repository.UpdateAsync(anamnesisToUpdate, request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Anamnesis Referral:{request.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}
