namespace IdentityServer.Application.Errors
{
    public class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message) 
            : base("Bad Request", message)
        {
        }
    }
}
