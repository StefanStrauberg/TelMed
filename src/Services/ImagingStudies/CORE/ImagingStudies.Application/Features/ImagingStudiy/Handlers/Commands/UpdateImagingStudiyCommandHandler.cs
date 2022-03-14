using AutoMapper;
using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Application.Exceptions;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands;
using ImagingStudies.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ImagingStudies.Application.Features.ImagingStudiy.Handlers.Commands
{
    public class UpdateImagingStudiyCommandHandler : IRequestHandler<UpdateImagingStudiyCommand>
    {
        private readonly IImagingStudyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateImagingStudiyCommandHandler> _logger;
        public UpdateImagingStudiyCommandHandler(
            IImagingStudyRepository repository,
            IMapper mapper,
            ILogger<UpdateImagingStudiyCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateImagingStudiyCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.UpdateAsync(_mapper.Map<ImagingStudy>(request)))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"ImagingStudy {request.Id} in Referral {request.ReferralId} is successfully updated.");
            return Unit.Value;
        }
    }
}
