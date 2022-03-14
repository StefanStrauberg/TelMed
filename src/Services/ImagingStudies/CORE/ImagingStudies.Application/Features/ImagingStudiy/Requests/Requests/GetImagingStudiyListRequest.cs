using ImagingStudies.Domain;
using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Requests.Requests
{
    public class GetImagingStudiyListRequest : IRequest<IReadOnlyList<ImagingStudy>>
    {
    }
}
