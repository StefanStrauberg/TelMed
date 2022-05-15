using AutoMapper;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly UserManager<Domain.ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Domain.ApplicationRole> _roleManager;
        public UpdateAccountCommandHandler(
            UserManager<Domain.ApplicationUser> userManager,
            IMapper mapper,
            RoleManager<Domain.ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user is null)
                throw new AccountBadRequestException(request.id);
            var role = await _roleManager.FindByIdAsync(request.model.Role); 
            if(role is null)
                throw new RoleBadRequestException(request.model.Role);
            _mapper.Map(request.model, user);
            user.Roles = new List<Guid>() { role.Id };
            await _userManager.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
