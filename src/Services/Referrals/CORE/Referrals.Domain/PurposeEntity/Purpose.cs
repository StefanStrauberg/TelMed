namespace Referrals.Domain.PurposeEntity
{
    /// <summary>
    /// The purpose of the consultation
    /// </summary>
    public class Purpose
    {
        /// <summary>
        /// The purpose category
        /// </summary>
        public PurposeGroup Group { get; set; }
        /// <summary>
        /// Description of the purpose
        /// </summary>
        public string Resume { get; set; }
    }
}
