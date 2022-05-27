using AutoMapper;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RegisterAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            if(await _userManager.FindByNameAsync(request.model.UserName) is not null)
                throw new ExistsAccountBadRequestException(request.model.UserName);
            if(!await _roleManager.RoleExistsAsync(request.model.Role))
                throw new RoleBadRequestException(request.model.Role);
            var user = _mapper.Map<ApplicationUser>(request.model);
            await _userManager.CreateAsync(user, request.model.Password);
            await _userManager.AddToRoleAsync(user, request.model.Role);
            return Unit.Value;
        }
    }
}
