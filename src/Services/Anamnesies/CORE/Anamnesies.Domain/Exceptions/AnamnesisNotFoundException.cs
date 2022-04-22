namespace Anamnesies.Domain.Exceptions
{
    public class AnamnesisNotFoundException : NotFoundException
    {
        public AnamnesisNotFoundException(string id) 
            : base($"The anamnesis with the identifier {id} was not found.")
        {
        }
    }
}