namespace IdentityServer.Application.Errors
{
    public class AccountBadRequest : BadRequestException
    {
        protected AccountBadRequest(string id) 
            : base($"The account with the identifier {id} was not found.")
        {
        }
    }
}
