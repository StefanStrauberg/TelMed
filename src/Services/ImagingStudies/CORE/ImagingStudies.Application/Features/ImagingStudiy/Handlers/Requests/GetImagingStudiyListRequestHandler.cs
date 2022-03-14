using ImagingStudies.Application.Contracts.Persistence;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Requests;
using ImagingStudies.Domain;
using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Handlers.Requests
{
    public class GetImagingStudiyListRequestHandler : IRequestHandler<GetImagingStudiyListRequest, IReadOnlyList<ImagingStudy>>
    {
        private readonly IImagingStudyRepository _repository;
        public GetImagingStudiyListRequestHandler(IImagingStudyRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<ImagingStudy>> Handle(GetImagingStudiyListRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
