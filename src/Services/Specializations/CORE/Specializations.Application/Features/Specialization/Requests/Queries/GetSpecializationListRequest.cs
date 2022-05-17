using MediatR;
using Specializations.Application.DTO;
using Specializations.Application.Specs;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetSpecializationListRequest(QuerySpecParams querySpecParams) : IRequest<PagedList<SpecializationDto>>;
}
