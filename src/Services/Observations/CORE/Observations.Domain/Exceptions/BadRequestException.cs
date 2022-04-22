namespace Observations.Domain.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message) 
            : base("Bad Request", message)
        {
        }
    }
}