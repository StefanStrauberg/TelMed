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
        private readonly IGrpcService _grpcService;
        public GetAccountsListRequestHandler(
            IMapper mapper,
            IApplicationUserRepository applicationUserRepository,
            IApplicationRoleRepository applicationRoleRepository,
            IGrpcService grpcService)
        {
            _mapper = mapper;
            _applicationUserRepository = applicationUserRepository;
            _applicationRoleRepository = applicationRoleRepository;
            _grpcService = grpcService;
        }
        public async Task<List<AccountDto>> Handle(GetAccountsListRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<AccountDto>>(await _applicationUserRepository.GetAllAsync(request.querySpecParams));
            //await Parallel.ForEachAsync(result, async (x, cancellationToken) => 
            //{
            //    x.Role = await _applicationRoleRepository.GetRoleNameById(x.Role);
            //    if (x.SpecializationId is not null)
            //        x.SpecializationId = await _grpcService.GetSpecName(x.SpecializationId);
            //    if (x.SpecializationId is not null)
            //        x.OrganizationId = await _grpcService.GetOrgName(x.OrganizationId);
            //});
            return result;
        }
    }
}
