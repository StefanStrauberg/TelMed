using Referrals.Domain;

namespace Referrals.Application.DTO
{
    public class CreateReferralDto
    {
        public Patient Patient { get; set; }
        public Guid AuthorId { get; set; }
    }
}
