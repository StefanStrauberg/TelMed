using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetRoleDetailRequest(string id) : IRequest<Domain.ApplicationRole>;
}