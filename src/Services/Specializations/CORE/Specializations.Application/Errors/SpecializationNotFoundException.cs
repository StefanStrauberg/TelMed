using BaseDomain.Errors;

namespace Specializations.Application.Errors
{
    public class SpecializationNotFoundException : NotFoundException
    {
        public SpecializationNotFoundException(string id) 
            : base($"The specialization with the identifier {id} was not found.")
        {
        }
    }
}