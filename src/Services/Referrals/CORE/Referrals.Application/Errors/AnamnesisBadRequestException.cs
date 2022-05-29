using BaseDomain.Errors;

namespace Referrals.Application.Errors
{
    public class AnamnesisBadRequestException : BadRequestException
    {
        public AnamnesisBadRequestException(string id)
            : base($"The anamnesis with the identifier {id} was not found.")
        {
        }
    }
}
