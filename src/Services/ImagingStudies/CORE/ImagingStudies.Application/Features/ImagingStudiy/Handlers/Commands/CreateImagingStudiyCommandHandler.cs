using AutoMapper;
using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands;
using ImagingStudies.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ImagingStudies.Application.Features.ImagingStudiy.Handlers.Commands
{
    public class CreateImagingStudiyCommandHandler : IRequestHandler<CreateImagingStudiyCommand, string>
    {
        private readonly IImagingStudyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateImagingStudiyCommandHandler> _logger;
        public CreateImagingStudiyCommandHandler(
            IImagingStudyRepository repository,
            IMapper mapper,
            ILogger<CreateImagingStudiyCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(CreateImagingStudiyCommand request, CancellationToken cancellationToken)
        {
            var imagingStudyEntity = _mapper.Map<ImagingStudy>(request);
            await _repository.CreateAsync(imagingStudyEntity);
            _logger.LogInformation($"ImagingStudy {imagingStudyEntity.Id} in Referral {imagingStudyEntity.ReferralId} is successfully created.");
            return imagingStudyEntity.Id;
        }
    }
}
