using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetRoleDetailRequest(string id) : IRequest<IdentityRole>;
}