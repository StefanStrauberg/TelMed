namespace Observations.Domain
{
    /// <summary>
    /// Image
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Image Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Image Size
        /// </summary>
        public ulong Size { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string Url { get; set; }
    }
}