using BaseDomain.Errors;

namespace IdentityServer.Application.Errors
{
    public class AccountBadRequestException : BadRequestException
    {
        public AccountBadRequestException(string id) 
            : base($"The account with the identifier {id} was not found.")
        {
        }
    }
}
