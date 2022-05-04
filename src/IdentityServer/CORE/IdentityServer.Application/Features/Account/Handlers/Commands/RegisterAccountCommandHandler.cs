using AutoMapper;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.Features.Account.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PasswordHasher = IdentityServer.Application.Security.PasswordHasher;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityServer.Domain.Account> _userManager;
        private readonly IAccountRepository _accountRepository;
        public RegisterAccountCommandHandler(
            IMapper mapper,
            UserManager<Domain.Account> userManager,
            IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _accountRepository = accountRepository;
        }
        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityServer.Domain.Account>(request.model);
            //await _userManager.CreateAsync(user, request.model.Password);
            await _userManager.CreateAsync(user);
            var hasher = new PasswordHasher(request.model.Password);
            user.PasswordHash = hasher.Hash;
            user.PasswordSalt = hasher.Salt;
            await _accountRepository.SеtHashByAccount(user);
            await _accountRepository.SеtSaltByAccount(user);
            await _userManager.AddToRoleAsync(user, request.model.Role);
            return Unit.Value;
        }
    }
}
