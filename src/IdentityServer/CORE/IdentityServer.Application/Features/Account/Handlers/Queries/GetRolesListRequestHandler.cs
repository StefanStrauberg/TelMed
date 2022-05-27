using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRolesListRequestHandler : IRequestHandler<GetRolesListRequest, IReadOnlyList<RoleDto>>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        public GetRolesListRequestHandler(
            RoleManager<ApplicationRole> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<RoleDto>> Handle(GetRolesListRequest request, CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<RoleDto>>( await _roleManager.Roles.ToListAsync());
    }
}
