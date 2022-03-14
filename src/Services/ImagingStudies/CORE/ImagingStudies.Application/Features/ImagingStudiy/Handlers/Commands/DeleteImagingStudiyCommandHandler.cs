using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Application.Exceptions;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ImagingStudies.Application.Features.ImagingStudiy.Handlers.Commands
{
    public class DeleteImagingStudiyCommandHandler : IRequestHandler<DeleteImagingStudiyCommand>
    {
        private readonly IImagingStudyRepository _repository;
        private readonly ILogger<DeleteImagingStudiyCommandHandler> _logger;
        public DeleteImagingStudiyCommandHandler(IImagingStudyRepository repository, ILogger<DeleteImagingStudiyCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteImagingStudiyCommand request, CancellationToken cancellationToken)
        {
            if (!await _repository.DeleteAsync(request.Id))
                throw new NotFoundException(nameof(request), request.Id);
            _logger.LogInformation($"ImagingStudy {request.Id} is successfully deleted.");
            return Unit.Value;
        }
    }
}
