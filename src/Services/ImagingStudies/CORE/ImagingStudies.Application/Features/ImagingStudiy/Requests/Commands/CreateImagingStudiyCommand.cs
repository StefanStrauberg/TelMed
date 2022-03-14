using ImagingStudies.Domain;
using MediatR;

namespace ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands
{
    public class CreateImagingStudiyCommand : IRequest<string>
    {
        public string ReferralId { get; set; }
        public DateTime Started { get; set; }
        public string Uid { get; set; }
        public string Description { get; set; }
        public List<Series> Series { get; set; }
    }
}
