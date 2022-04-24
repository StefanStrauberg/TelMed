using MediatR;
using Observations.Application.Specs;

namespace Observations.Application.Features.Observation.Requests.Queries
{
    public record GetObservationsCountRequest(QuerySpecParams querySpecParams) : IRequest<long>;
}