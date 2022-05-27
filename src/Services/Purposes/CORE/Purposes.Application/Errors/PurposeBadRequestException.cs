using BaseDomain.Errors;

namespace Purposes.Application.Errors
{
    public class PurposeBadRequestException : BadRequestException
    {
        public PurposeBadRequestException(string id)
            : base($"The purpouse with the identifier {id} was not found.")
        {
        }
    }
}
