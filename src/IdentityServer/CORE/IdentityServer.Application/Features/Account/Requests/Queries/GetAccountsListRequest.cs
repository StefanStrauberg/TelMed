using IdentityServer.Application.DTOs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetAccountsListRequest : IRequest<IReadOnlyList<AccountDto>>;
}
