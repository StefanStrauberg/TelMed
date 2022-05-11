using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountDetailRequestHandler : IRequestHandler<GetAccountDetailRequest, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        public GetAccountDetailRequestHandler(
            IMapper mapper,
            UserManager<Domain.ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<AccountDto> Handle(GetAccountDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is null)
                throw new AccountBadRequestException(request.id);
            var result = _mapper.Map<AccountDto>(user);
            return result;
        }
    }
}
