using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetSpecializationDetailRequest(string id) : IRequest<SpecializationDto>;
}
