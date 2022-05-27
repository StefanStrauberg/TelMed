using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRolesListRequestHandler : IRequestHandler<GetRolesListRequest, IReadOnlyList<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public GetRolesListRequestHandler(
            IMapper mapper,
            RoleManager<ApplicationRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<IReadOnlyList<RoleDto>> Handle(GetRolesListRequest request, CancellationToken cancellationToken)
        {
            //_mapper.Map<IReadOnlyList<RoleDto>>(await _applicationRoleRepository.GetAllAsync());
            var roles = _roleManager.Roles.ToList();
            return _mapper.Map<IReadOnlyList<RoleDto>>(roles);
        } 
    }
}
