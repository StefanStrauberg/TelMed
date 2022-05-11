using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountListRequestHandler : IRequestHandler<GetAccountListRequest, List<AccountDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        private readonly RoleManager<Domain.ApplicationRole> _roleManager;
        public GetAccountListRequestHandler(
            IMapper mapper,
            UserManager<Domain.ApplicationUser> userManager,
            RoleManager<Domain.ApplicationRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<List<AccountDto>> Handle(GetAccountListRequest request, CancellationToken cancellationToken)
            => Task.FromResult(_mapper.Map<List<AccountDto>>(_userManager.Users.ToList()));
    }
}
