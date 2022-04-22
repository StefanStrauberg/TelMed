using Referrals.Domain;

namespace Referrals.Application.DTO
{
    public class UpdateReferralDto
    {
        public string Id { get; set; }
        public Patient Patient { get; set; }
    }
}
