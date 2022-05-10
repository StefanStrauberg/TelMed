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
        private readonly UserManager<Domain.Account> _userManager;
        public GetAccountListRequestHandler(
            IMapper mapper,
            UserManager<Domain.Account> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public Task<List<AccountDto>> Handle(GetAccountListRequest request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            var result = _mapper.Map<List<AccountDto>>(users);
            result.ForEach(x => x.Role = string.Join(",", _userManager.GetRolesAsync(users.First(u => u.Id == x.Id)).GetAwaiter().GetResult()));
            return Task.FromResult(result);
        }
    }
}
