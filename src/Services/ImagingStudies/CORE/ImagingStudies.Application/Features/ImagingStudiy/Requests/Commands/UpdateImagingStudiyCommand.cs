using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands
{
    public class UpdateImagingStudiyCommand : IRequest
    {
        public string Id { get; set; }
        public string ReferralId { get; set; }
        public string Uid { get; set; }
        public string Description { get; set; }
    }
}
