using Observations.Domain.Common;

namespace Observations.Domain
{
    /// <summary>
    /// Observation
    /// </summary>
    public class Observation : BaseDomainEntity
    {
        public string ReferralId { get; set; }
        /// <summary>
        /// Date of observation
        /// </summary>
        public DateTime ObservationDate { get; set; }
        /// <summary>
        /// Description of the observation
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Surveillance images
        /// </summary>
        public List<Attachment> Attachments { get; set; }
    }
}
