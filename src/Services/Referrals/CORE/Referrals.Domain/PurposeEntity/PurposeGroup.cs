namespace Referrals.Domain.PurposeEntity
{
    /// <summary>
    /// Category of the purpose
    /// </summary>
    public enum PurposeGroup
    {
        /// <summary>
        /// Identification (correction, determination) clinical diagnosis
        /// </summary>
        Diagnosis = 1,
        /// <summary>
        /// Identification (correction, determination) survey tactics (laboratory, functional, instrumental, etc)
        /// </summary>
        Observation = 2,
        /// <summary>
        /// Identification (correction, determination) survey tactics (conservative, operational)
        /// </summary>
        Therapy = 3,
        /// <summary>
        /// Resolution of the issue of planned hospitalization (approval of the date of planned gospitalization)
        /// </summary>
        Hospital = 4,
        /// <summary>
        /// Another
        /// </summary>
        Other = 5
    }
}