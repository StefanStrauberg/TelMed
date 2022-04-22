namespace Observations.Domain.Exceptions
{
    public class ObservationNotFoundException : NotFoundException
    {
        public ObservationNotFoundException(string id) 
            : base($"The observation with the identifier {id} was not found.")
        {
        }
    }
}