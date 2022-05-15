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
        private readonly UserManager<IdentityServer.Domain.ApplicationUser> _userManager;
        private readonly JwtHandler _jwtHandler;
        public LoginAccountCommandHandler(
            UserManager<Domain.ApplicationUser> userManager,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        public async Task<AuthResponseDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.model.Login);
            if (user is null)
                throw new AccountUnauthorizedException("Invalid login.");
            if (!await _userManager.CheckPasswordAsync(user, request.model.Password))
                throw new AccountUnauthorizedException("Invalid password.");
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new AuthResponseDto { IsAuthSuccessful = true, Token = token };
        }
    }
}
