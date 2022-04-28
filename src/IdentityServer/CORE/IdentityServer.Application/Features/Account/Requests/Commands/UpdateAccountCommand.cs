using IdentityServer.Application.DTOs;
using MediatR;

namespace IdentityServer.Application.Features.Account.Requests.Commands
{
    public record UpdateAccountCommand(AccountForUpdateDto model, string id) : IRequest;
}
