using IdentityServer.Application.DTOs;
using IdentityServer.Application.Specs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetAccountsListRequest(QuerySpecParams querySpecParams) : IRequest<List<AccountDto>>;
}
