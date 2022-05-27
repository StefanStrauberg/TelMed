using BaseDomain.Errors;

namespace IdentityServer.Application.Errors
{
    public class ExistsAccountBadRequestException : BadRequestException
    {
        public ExistsAccountBadRequestException(string message) 
            : base($"The account with the identifier {message} is exists.")
        {
        }
    }
}