namespace Referrals.Domain.Exceptions
{
    public class ReferralBadRequestException : BadRequestException
    {
        public ReferralBadRequestException(string id) 
            : base($"The referral with the identifier {id} was not found.")
        {
        }
    }
}
