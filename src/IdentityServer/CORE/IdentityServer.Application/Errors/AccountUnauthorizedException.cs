namespace IdentityServer.Application.Errors
{
    public class AccountUnauthorizedException : UnauthorizedException
    {
        public AccountUnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
