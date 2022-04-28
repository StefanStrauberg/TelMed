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
        private readonly IMapper _mapper;
        private readonly IAccountRepository _repository;
        public GetAccountDetailRequestHandler(
            IMapper mapper,
            IAccountRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<AccountDto> Handle(GetAccountDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.id);
            if (user == null)
                throw new AccountBadRequestException(request.id);
            return _mapper.Map<AccountDto>(user);
        }
    }
}
