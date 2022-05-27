using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using IdentityServer.Application.GrpcServices;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountsListRequestHandler : IRequestHandler<GetAccountsListRequest, IReadOnlyList<AccountDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IGrpcService _grpcService;
        public GetAccountsListRequestHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IGrpcService grpcService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _grpcService = grpcService;
        }
        public async Task<IReadOnlyList<AccountDto>> Handle(GetAccountsListRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<IReadOnlyList<AccountDto>>(await _userManager.Users.ToListAsync());
            await Parallel.ForEachAsync(data, async (x, cancellationToken) =>
            {
                //x.Role = await _applicationRoleRepository.GetRoleNameById(x.Role);
                if (x.SpecializationId is not null)
                    x.SpecializationId = await _grpcService.GetSpecName(x.SpecializationId);
                if (x.SpecializationId is not null)
                    x.OrganizationId = await _grpcService.GetOrgName(x.OrganizationId);
            });
            return data;
        }
    }
}
