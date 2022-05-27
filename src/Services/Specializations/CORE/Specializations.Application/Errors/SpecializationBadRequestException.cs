using BaseDomain.Errors;

namespace Specializations.Application.Errors
{
    public class SpecializationBadRequestException : BadRequestException
    {
        public SpecializationBadRequestException(string id) 
            : base($"The specialization with the identifier {id} was not found.")
        {
        }
    }
}