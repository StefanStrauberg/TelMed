using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.DTOs;
using IdentityServer.Application.Errors;
using IdentityServer.Application.Features.Account.Requests.Commands;
using IdentityServer.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityServer.Application.Features.Account.Handlers.Commands
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, AuthResponseDto>
    {
        private readonly UserManager<IdentityServer.Domain.Account> _userManager;
        private readonly JwtHandler _jwtHandler;
        private readonly IAccountRepository _accountRepository;
        public LoginAccountCommandHandler(
            UserManager<Domain.Account> userManager,
            JwtHandler jwtHandler,
            IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            _accountRepository = accountRepository;
        }
        public async Task<AuthResponseDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.model.Login);
            if (user is null)
                throw new AccountUnauthorizedException("Invalid login.");
            //if (!await _userManager.CheckPasswordAsync(user, request.model.Password))
            //    throw new AccountUnauthorizedException("Invalid password.");
            var hasher = new PasswordHasher(request.model.Password, user.PasswordSalt);
            if (user.PasswordHash != hasher.Hash)
                throw new AccountUnauthorizedException("Invalid password.");

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new AuthResponseDto { Token = token };
        }
    }
}
