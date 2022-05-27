using BaseDomain.Errors;

namespace IdentityServer.Application.Errors
{
    public class ExistsRoleBadRequestException : BadRequestException
    {
        public ExistsRoleBadRequestException(string message) 
            : base($"The role with the identifier {message} is exists.")
        {
        }
    }
}