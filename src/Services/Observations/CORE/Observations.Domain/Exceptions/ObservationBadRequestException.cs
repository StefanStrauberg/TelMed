namespace Observations.Domain.Exceptions
{
    public class ObservationBadRequestException : BadRequestException
    {
        public ObservationBadRequestException(string id) 
            : base($"The observation with the identifier {id} was not found.")
        {
        }
    }
}