using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRolesListRequestHandler : IRequestHandler<GetRolesListRequest, IReadOnlyList<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRoleRepository _applicationRoleRepository;
        public GetRolesListRequestHandler(
            IMapper mapper,
            IApplicationRoleRepository applicationRoleRepository)
        {
            _mapper = mapper;
            _applicationRoleRepository = applicationRoleRepository;
        }

        public async Task<IReadOnlyList<RoleDto>> Handle(GetRolesListRequest request, CancellationToken cancellationToken)
            => _mapper.Map<IReadOnlyList<RoleDto>>(await _applicationRoleRepository.GetAllAsync());
    }
}
