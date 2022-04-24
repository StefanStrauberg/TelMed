using MediatR;
using Specializations.Application.Specs;

namespace Specializations.Application.Features.Specialization.Requests.Queries
{
    public record GetSpecializationsCountRequest(QuerySpecParams querySpecParams) : IRequest<long>;
}