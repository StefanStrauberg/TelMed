using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountsCountRequestHandler : IRequestHandler<GetAccountsCountRequest, long>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        public GetAccountsCountRequestHandler(IApplicationUserRepository applicationUserRepository)
            => _applicationUserRepository = applicationUserRepository;
        public async Task<long> Handle(GetAccountsCountRequest request, CancellationToken cancellationToken)
            => await _applicationUserRepository.CountAsync(request.querySpecParams);
    }
}
