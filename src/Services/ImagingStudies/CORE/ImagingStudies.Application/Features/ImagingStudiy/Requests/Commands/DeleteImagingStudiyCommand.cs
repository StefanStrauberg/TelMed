using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands
{
    public class DeleteImagingStudiyCommand : IRequest
    {
        public string Id { get; set; }
    }
}
