namespace Specializations.Domain.Exceptions
{
    public class SpecializationBadRequestException : BadRequestException
    {
        public SpecializationBadRequestException(string id) 
            : base($"The specialization with the identifier {id} was not found.")
        {
        }
    }
}