namespace Specializations.Domain.Exceptions
{
    public class SpecializationNotFoundException : NotFoundException
    {
        public SpecializationNotFoundException(string id) 
            : base($"The specialization with the identifier {id} was not found.")
        {
        }
    }
}