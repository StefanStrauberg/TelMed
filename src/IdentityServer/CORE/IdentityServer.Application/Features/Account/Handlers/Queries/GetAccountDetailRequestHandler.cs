using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountDetailRequestHandler : IRequestHandler<GetAccountDetailRequest, AccountDto>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;
        public GetAccountDetailRequestHandler(
            IMapper mapper,
            IApplicationUserRepository applicationUserRepository)
        {
            _mapper = mapper;
            _applicationUserRepository = applicationUserRepository;
        }
        public async Task<AccountDto> Handle(GetAccountDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _applicationUserRepository.GetByIdAsync(request.id);
            if (user is null)
                throw new AccountBadRequestException(request.id.ToString());
            return _mapper.Map<AccountDto>(user);
        }
    }
}
