using BaseDomain.Errors;

namespace Referrals.Application.Errors
{
    public class ReferralBadRequestException : BadRequestException
    {
        public ReferralBadRequestException(string id) 
            : base($"The referral with the identifier {id} was not found.")
        {
        }
    }
}
