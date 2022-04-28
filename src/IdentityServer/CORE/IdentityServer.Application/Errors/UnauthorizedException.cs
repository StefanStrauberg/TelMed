namespace IdentityServer.Application.Errors
{
    public class UnauthorizedException : ApplicationException
    {
        protected UnauthorizedException(string message) 
            : base("Unauthorized", message)
        {
        }
    }
}
