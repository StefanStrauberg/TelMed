using IdentityServer.Application.DTOs;
using IdentityServer.Application.Features.Account.Requests.Queries;
using MediatR;

namespace IdentityServer.Application.Features.Account.Handlers.Queries
{
    public class GetAccountDetailRequestHandler : IRequestHandler<GetAccountDetailRequest, AccountDto>
    {
        public Task<AccountDto> Handle(GetAccountDetailRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
