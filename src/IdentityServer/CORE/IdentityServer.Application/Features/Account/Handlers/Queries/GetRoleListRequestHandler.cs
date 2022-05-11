using System.Net.Mime;
using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleListRequestHandler : IRequestHandler<GetRoleListRequest, List<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.ApplicationRole> _roleMagaer;
        public GetRoleListRequestHandler(RoleManager<Domain.ApplicationRole> roleMagaer, IMapper mapper)
        {
            _roleMagaer = roleMagaer;
            _mapper = mapper;
        } 
        public Task<List<RoleDto>> Handle(GetRoleListRequest request, CancellationToken cancellationToken)
            => Task.FromResult(_mapper.Map<List<RoleDto>>( _roleMagaer.Roles.ToList()));
    }
}
