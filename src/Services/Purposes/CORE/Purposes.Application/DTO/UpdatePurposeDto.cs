using Purposes.Domain;

namespace Purposes.Application.DTO
{
    public class UpdatePurposeDto
    {
        public string ReferralId { get; set; }
        public PurposeGroup Group { get; set; }
        public string Resume { get; set; }
    }
}
