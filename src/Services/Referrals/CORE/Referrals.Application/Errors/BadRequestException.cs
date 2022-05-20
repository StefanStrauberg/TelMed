namespace Referrals.Application.Errors
{
    public class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message) 
            : base("Bad Request", message)
        {
        }
    }
}
