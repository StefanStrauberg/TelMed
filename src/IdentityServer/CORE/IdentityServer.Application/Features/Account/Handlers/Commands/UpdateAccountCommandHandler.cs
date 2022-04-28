using AutoMapper;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly UserManager<Domain.Account> _userManager;
        private readonly IMapper _mapper;
        public UpdateAccountCommandHandler(
            UserManager<Domain.Account> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is null)
                throw new AccountBadRequestException(request.id);
            _mapper.Map(request.model, user);
            await _userManager.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
