using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public class GetSpecializationListRequest : IRequest<IReadOnlyList<SpecializationDto>>
    {
    }
}
