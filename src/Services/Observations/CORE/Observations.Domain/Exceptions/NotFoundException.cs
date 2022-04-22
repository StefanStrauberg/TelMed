namespace Observations.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        protected NotFoundException(string message) 
            : base("Not Found", message)
        {
        }
    }
}