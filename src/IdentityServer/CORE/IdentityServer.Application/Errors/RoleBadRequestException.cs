namespace IdentityServer.Application.Errors
{
    public class RoleBadRequestException : BadRequestException
    {
        public RoleBadRequestException(string id) 
            : base($"The role with the identifier {id} was not found.")
        {
        }
    }
}