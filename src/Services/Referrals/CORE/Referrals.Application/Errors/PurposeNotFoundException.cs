using BaseDomain.Errors;

namespace Purposes.Application.Errors
{
    public class PurposeNotFoundException : NotFoundException
    {
        public PurposeNotFoundException(string id)
            : base($"The purpouse with the identifier {id} was not found.")
        {
        }
    }
}
