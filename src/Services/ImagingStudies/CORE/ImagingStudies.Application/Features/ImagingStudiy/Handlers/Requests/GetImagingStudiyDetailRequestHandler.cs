using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Application.Exceptions;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Requests;
using ImagingStudies.Domain;
using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Handlers.Requests
{
    public class GetImagingStudiyDetailRequestHandler : IRequestHandler<GetImagingStudiyDetailRequest, ImagingStudy>
    {
        private readonly IImagingStudyRepository _repository;
        public GetImagingStudiyDetailRequestHandler(IImagingStudyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ImagingStudy> Handle(GetImagingStudiyDetailRequest request, CancellationToken cancellationToken)
        {
            var imagingStudy = await _repository.GetAsync(request.Id);
            if (imagingStudy is null)
                throw new NotFoundException(nameof(request), request.Id);
            return imagingStudy;
        }
    }
}
