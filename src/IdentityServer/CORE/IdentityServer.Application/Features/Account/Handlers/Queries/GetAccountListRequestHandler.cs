using System.Linq;
using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountListRequestHandler : IRequestHandler<GetAccountListRequest, IReadOnlyList<AccountDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _repository;
        private readonly UserManager<Domain.Account> _userManager;
        public GetAccountListRequestHandler(
            IMapper mapper,
            IAccountRepository repository,
            UserManager<Domain.Account> userManager)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }
        public async Task<IReadOnlyList<AccountDto>> Handle(GetAccountListRequest request, CancellationToken cancellationToken)
           => _mapper.Map<IReadOnlyList<AccountDto>>(await _repository.GetAllAsync());
    }
}
