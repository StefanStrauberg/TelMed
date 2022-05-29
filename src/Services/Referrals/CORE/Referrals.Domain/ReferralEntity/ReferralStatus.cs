namespace Referrals.Domain.ReferralEntity
{
    /// <summary>
    /// Status consultation
    /// </summary>
    public enum ReferralStatus
    {
        /// <summary>
        /// Referral underformed
        /// </summary>
        Incomplete,
        /// <summary>
        /// Referral is opened
        /// </summary>
        Opened,
        /// <summary>
        /// Referral is closed
        /// </summary>
        Closed,
        /// <summary>
        /// Referral need attention
        /// </summary>
        NeedAttention,
        /// <summary>
        /// Referral is closed
        /// </summary>
        Canceled
    }
}