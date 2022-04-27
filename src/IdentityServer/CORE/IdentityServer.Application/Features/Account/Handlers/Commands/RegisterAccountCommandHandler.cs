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
            var result = await _userManager.CreateAsync(user, request.model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                //TODO throw new Validation Exception();
            }
            await _userManager.AddToRoleAsync(user, request.model.Role.ToString());
            throw new NotImplementedException();
        }
    }
}
