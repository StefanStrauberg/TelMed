using Purposes.Domain;

namespace Purposes.Application.DTO
{
    public class PurposeDto
    {
        public string Id { get; set; }
        public string ReferralId { get; set; }
        public PurposeGroup Group { get; set; }
        public string Resume { get; set; }
    }
}
