namespace Referrals.Domain.AnamnesisEntity
{
    /// <summary>
    /// Anamnesis of the disease
    /// </summary>
    public class Anamnesis
    {
        public AnamnesisCategory CategoryId { get; set; }
        /// <summary>
        /// General information about the patient
        /// </summary>
        public string Summary { get; set; }
    }
}
