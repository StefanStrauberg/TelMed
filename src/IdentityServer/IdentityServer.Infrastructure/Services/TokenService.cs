using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityServer.Core.Entities;
using IdentityServer.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(
            IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }
        public string CreateToken(Account account)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.SerialNumber, account.Id),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.NameIdentifier, account.UserName),
                new Claim(ClaimTypes.GivenName, account.FirstName),
                new Claim(ClaimTypes.Surname, account.LastName),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
                new Claim("SpecializationId" ,account.SpecializationId),
                new Claim("OrganizationId", account.OrganizationId)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_config["Token:LifeTime"])),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}