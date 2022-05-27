using BaseDomain.Specs;
using MediatR;
using Specializations.Application.DTO;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetSpecializationListRequest(QuerySpecParams querySpecParams) : IRequest<PagedList<SpecializationDto>>;
}
