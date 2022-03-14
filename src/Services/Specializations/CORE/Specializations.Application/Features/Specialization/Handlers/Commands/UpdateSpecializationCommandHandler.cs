using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Exceptions;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Features.Specialization.Handlers.Commands
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand>
    {
        private readonly ISpecializationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSpecializationCommandHandler> _logger;
        public UpdateSpecializationCommandHandler(
            ISpecializationRepository repository,
            IMapper mapper,
            ILogger<UpdateSpecializationCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.UpdateAsync(_mapper.Map<Domain.Specialization>(request)))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Specialization {request.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}
