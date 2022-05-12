using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetRoleDetailRequestHandler : IRequestHandler<GetRoleDetailRequest, RoleDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRoleRepository _applicationRoleRepository;
        public GetRoleDetailRequestHandler(
            IMapper mapper,
            IApplicationRoleRepository applicationRoleRepository)
        {
            _mapper = mapper;
            _applicationRoleRepository = applicationRoleRepository;
        }

        public async Task<RoleDto> Handle(GetRoleDetailRequest request, CancellationToken cancellationToken)
            => _mapper.Map<RoleDto>(await _applicationRoleRepository.GetAsync(request.id));
    }
}