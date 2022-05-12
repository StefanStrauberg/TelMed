using IdentityServer.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Requests.Queries
{
    public record GetRolesListRequest : IRequest<IReadOnlyList<RoleDto>>;
}
