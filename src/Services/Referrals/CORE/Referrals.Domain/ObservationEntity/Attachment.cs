namespace Referrals.Domain.ObservationEntity
{
    /// <summary>
    /// Image
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Image name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image size
        /// </summary>
        public ulong Size { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string Url { get; set; }
    }
}