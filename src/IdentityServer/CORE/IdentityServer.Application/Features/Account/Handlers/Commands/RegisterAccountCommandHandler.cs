using AutoMapper;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityServer.Domain.Account> _userManager;
        public RegisterAccountCommandHandler(
            IMapper mapper,
            UserManager<Domain.Account> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityServer.Domain.Account>(request.model);
            await _userManager.CreateAsync(user, request.model.Password);
            await _userManager.AddToRoleAsync(user, request.model.Role);
            return Unit.Value;
        }
    }
}
