using Anamnesies.Domain;

namespace Anamnesies.Application.DTO
{
    public class AnamnesisDto
    {
        public string ReferralId { get; set; }
        public AnamnesisCategory CategoryId { get; set; }
        public string Summary { get; set; }
    }
}
