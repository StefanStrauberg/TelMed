using IdentityServer.Application.DTOs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetAccountDetailRequest(Guid id) : IRequest<AccountDto>;
}
