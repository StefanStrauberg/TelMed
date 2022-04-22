using Anamnesies.Domain;

namespace Anamnesies.Application.DTO
{
    public class UpdateAnamnesisDto
    {
        public string ReferralId { get; set; }
        public AnamnesisCategory CategoryId { get; set; }
        public string Summary { get; set; }
    }
}