using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public class GetSpecializationDetailRequest : IRequest<SpecializationDto>
    {
        public string Id { get; set; }
    }
}
