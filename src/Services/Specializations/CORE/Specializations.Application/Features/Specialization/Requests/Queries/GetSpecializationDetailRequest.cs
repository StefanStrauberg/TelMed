using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetSpecializationDetailRequest(Guid id) : IRequest<SpecializationDto>;
}
