using MediatR;
using Organizations.Application.Specs;

namespace Organizations.Application.Features.Organization.Requests.Queries
{
    public record GetOrganizationsCountRequest(QuerySpecParams querySpecParams) : IRequest<long>;
}