using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Application.GrpcServices;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountsListRequestHandler : IRequestHandler<GetAccountsListRequest, IReadOnlyList<AccountDto>>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationRoleRepository _applicationRoleRepository;
        private readonly IMapper _mapper;
        private readonly IGrpcService _grpcService;
        public GetAccountsListRequestHandler(
            IMapper mapper,
            IGrpcService grpcService,
            IApplicationUserRepository applicationUserRepository,
            IApplicationRoleRepository applicationRoleRepository)
        {
            _mapper = mapper;
            _grpcService = grpcService;
            _applicationUserRepository = applicationUserRepository;
            _applicationRoleRepository = applicationRoleRepository;
        }
        public async Task<IReadOnlyList<AccountDto>> Handle(GetAccountsListRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<IReadOnlyList<AccountDto>>(await _applicationUserRepository.GetAllAsync());
            await Parallel.ForEachAsync(data, async (x, cancellationToken) =>
            {
                if (x.SpecializationId is not null)
                    x.SpecializationId = await _grpcService.GetSpecName(x.SpecializationId);
                if (x.SpecializationId is not null)
                    x.OrganizationId = await _grpcService.GetOrgName(x.OrganizationId);
            });
            return data;
        }
    }
}
