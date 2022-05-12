using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Application.GrpcServices;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountsListRequestHandler : IRequestHandler<GetAccountsListRequest, List<AccountDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationRoleRepository _applicationRoleRepository;
        private readonly SpecializationGrpcService _specializationGrpcService;
        private readonly OrganizationGrpcService _organizationGrpcService;
        public GetAccountsListRequestHandler(
            IMapper mapper,
            IApplicationUserRepository applicationUserRepository,
            IApplicationRoleRepository applicationRoleRepository,
            SpecializationGrpcService specializationGrpcService,
            OrganizationGrpcService organizationGrpcService)
        {
            _mapper = mapper;
            _applicationUserRepository = applicationUserRepository;
            _applicationRoleRepository = applicationRoleRepository;
            _specializationGrpcService = specializationGrpcService;
            _organizationGrpcService = organizationGrpcService;
        }
        public async Task<List<AccountDto>> Handle(GetAccountsListRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<AccountDto>>(await _applicationUserRepository.GetAllAsync(request.querySpecParams));
            result.ForEach(x => 
            {
                x.Role = _applicationRoleRepository.GetRoleNameById(x.Role).GetAwaiter().GetResult();
                if (x.SpecializationId is not null)
                    x.SpecializationId = _specializationGrpcService.GetSpecName(x.SpecializationId).GetAwaiter().GetResult();
                if (x.SpecializationId is not null)
                    x.OrganizationId = _organizationGrpcService.GetOrgName(x.OrganizationId).GetAwaiter().GetResult();
            });
            return result;
        }
    }
}
