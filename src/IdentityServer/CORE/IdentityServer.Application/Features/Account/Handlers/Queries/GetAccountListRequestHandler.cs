using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountListRequestHandler : IRequestHandler<GetAccountListRequest, IReadOnlyList<AccountDto>>
    {
        public Task<IReadOnlyList<AccountDto>> Handle(GetAccountListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
