using Referrals.Domain.AnamnesisEntity;

namespace Referrals.Application.DTO.AnamnesisDtos
{
    public class AnamnesisDto
    {
        public AnamnesisCategory CategoryId { get; set; }
        public string Summary { get; set; }
    }
}