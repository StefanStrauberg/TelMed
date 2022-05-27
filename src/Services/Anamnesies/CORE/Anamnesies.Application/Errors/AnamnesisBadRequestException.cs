using BaseDomain.Errors;

namespace Anamnesies.Application.Errors
{
    public class AnamnesisBadRequestException : BadRequestException
    {
        public AnamnesisBadRequestException(string id)
            : base($"The anamnesis with the identifier {id} was not found.")
        {
        }
    }
}
