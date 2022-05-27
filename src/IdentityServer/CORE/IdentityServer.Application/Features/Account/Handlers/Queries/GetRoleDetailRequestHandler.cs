using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleDetailRequestHandler : IRequestHandler<GetRoleDetailRequest, RoleDto>
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        public GetRoleDetailRequestHandler(
            RoleManager<ApplicationRole> roleManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetRoleDetailRequest request, CancellationToken cancellationToken)
            => _mapper.Map<RoleDto>(await _roleManager.FindByIdAsync(request.id.ToString()));
    }
}