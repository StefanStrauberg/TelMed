using ImagingStudies.Domain;
using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Requests.Requests
{
    public class GetImagingStudiyDetailRequest : IRequest<ImagingStudy>
    {
        public string Id { get; set; }
    }
}
