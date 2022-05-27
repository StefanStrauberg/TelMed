using BaseDomain;

namespace Anamnesies.Domain
{
    /// <summary>
    /// Anamnesis of the disease
    /// </summary>
    public class Anamnesis : BaseDomainEntity
    {
        public string ReferralId { get; set; }
        public AnamnesisCategory CategoryId { get; set; }
        /// <summary>
        /// general information about the patient
        /// </summary>
        public string Summary { get; set; }
    }
}
