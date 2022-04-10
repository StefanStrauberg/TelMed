using IdentityServer.Core.Entities;

namespace IdentityServer.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Account account);
    }
}