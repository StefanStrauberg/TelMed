using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Referrals.Application.Contracts.Persistence;
using Referrals.Application.Exceptions;
using Referrals.Application.Features.Patient.Requests.Commands;

namespace Referrals.Application.Features.Patient.Handlers.Commands
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePatientCommandHandler> _logger;
        public UpdatePatientCommandHandler(
            IPatientRepository repository,
            IMapper mapper,
            ILogger<UpdatePatientCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientToUpdate = _mapper.Map<Domain.PatientEntity.Patient>(request);
            if (!await _repository.UpdateAsync(patientToUpdate))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"Patient Referral:{request.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}
