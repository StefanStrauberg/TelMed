using IdentityServer.Application.Specs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetAccountsCountRequest(QuerySpecParams querySpecParams) : IRequest<long>;
}
